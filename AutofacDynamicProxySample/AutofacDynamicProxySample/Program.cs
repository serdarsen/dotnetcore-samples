using System;

using Autofac;
using Autofac.Extras.DynamicProxy;

namespace AutofacDynamicProxySample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure builder
            var builder = new ContainerBuilder();

            builder.Register(i => new Logger(Console.Out));
            builder.Register(i => new CacheManager());
            builder.RegisterType<Calculator>()
                   .As<ICalculator>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(Logger))
                   .InterceptedBy(typeof(CacheManager));

            var container = builder.Build();

            // Run calculator
            var calculator = container.Resolve<ICalculator>();
            calculator.Add(85, 95);
            calculator.Add(85, 95);
            calculator.Add(442, 558);
        }
    }
}
