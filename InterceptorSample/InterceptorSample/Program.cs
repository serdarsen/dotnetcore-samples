using System;

using Autofac;
using Autofac.Extras.DynamicProxy;
using InterceptorSample.Requests;
using InterceptorSample.Services;

namespace InterceptorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure builder
            var builder = new ContainerBuilder();

            builder.Register(i => new PermissionInterceptor(Console.Out));
            builder.RegisterType<XService>()
                   .As<IXService>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(PermissionInterceptor));

            var container = builder.Build();

            // Run XService methods
            var xService = container.Resolve<IXService>();
            xService.DoX(new ARequest());
            xService.DoY(new BRequest());
            xService.DoZ(new OtherRequest());
            xService.DoW(new A1Request());
        }
    }
}
