using System;
using System.Collections.Generic;
using System.Linq;

using Castle.DynamicProxy;

namespace AutofacDynamicProxySample
{
    public class CacheManager : IInterceptor
    {
        private Dictionary<string, object> cache = new Dictionary<string, object>();

        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";

            var args = string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()));

            var cacheKey = $"{name}|{args}";

            cache.TryGetValue(cacheKey, out object returnValue);
            if (returnValue == null)
            {
                invocation.Proceed();
                returnValue = invocation.ReturnValue;
                
                Console.WriteLine(cacheKey + " adding to cache...");
                cache.Add(cacheKey, returnValue);
            }
            else
            {
                Console.WriteLine(cacheKey + " reading from cache...");
                invocation.ReturnValue = returnValue;
            }
        }
    }
}