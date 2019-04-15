using System;
using System.IO;
using System.Linq;

using Castle.DynamicProxy;

namespace AutofacDynamicProxySample
{
    public class Logger : IInterceptor
    {
        readonly TextWriter _writer;
        public Logger(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            this._writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";

            var args = string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()));
            
            var baseType = invocation.Arguments[0].GetType().BaseType; // loop edilecek

            _writer.WriteLine($"Calling: {name}");
            _writer.WriteLine($"Args: {args}");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            invocation.Proceed(); //Intercepted method is executed here.
            watch.Stop();
            var executionTime = watch.ElapsedMilliseconds;

            _writer.WriteLine($"Done: result was {invocation.ReturnValue}");
            _writer.WriteLine($"Execution Time: {executionTime} ms.");
            _writer.WriteLine();
        }
    }
}