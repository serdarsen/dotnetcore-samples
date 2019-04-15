using System;
using System.IO;
using System.Linq;

using Castle.DynamicProxy;
using InterceptorSample.Requests;
using Shouldly;

namespace InterceptorSample
{
    public class PermissionInterceptor : IInterceptor
    {
        private readonly TextWriter _writer;

        public PermissionInterceptor(TextWriter writer)
        {
            _writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            var isCorrect = true;
            var methodName = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            var parameterList = invocation.Arguments;
            var typeOfBaseRequest = typeof(BaseRequest);

            foreach (var parameter in parameterList)
            {
                var type = parameter.GetType().BaseType;
                var baseType = type;
                var isContinue = true;
                while (isContinue)
                {
                    if (type == typeof(object))
                    {
                        if (baseType != typeOfBaseRequest)
                        {
                            _writer.WriteLine();
                            _writer.WriteLine($"{methodName}");
                            _writer.WriteLine($"{parameter} not inherited from {typeOfBaseRequest}");
                            _writer.WriteLine();
                            isCorrect = false;
                        }
                        isContinue = false;
                    }

                    baseType = type;
                    type = type.BaseType;
                }
            }

            if (isCorrect)
            {
                invocation.Proceed();
            }
        }
    }
}