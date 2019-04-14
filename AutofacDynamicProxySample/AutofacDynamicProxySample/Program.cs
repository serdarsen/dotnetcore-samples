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
            builder.RegisterType<Calculator>()
                   .As<ICalculator>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(Logger));

            var container = builder.Build();

            // Run calculator
            var calculator = container.Resolve<ICalculator>();
            calculator.Add(8, 9);
        }
    }
}
