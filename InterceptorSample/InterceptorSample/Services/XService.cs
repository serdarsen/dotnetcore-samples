using System;
using InterceptorSample.Requests;

namespace InterceptorSample.Services
{
    public class XService : IXService
    {
        public void DoX(ARequest request)
        {
            Console.WriteLine("DoX");
        }

        public void DoY(BRequest request)
        {
            Console.WriteLine("DoY");
        }

        public void DoZ(OtherRequest request)
        {
            Console.WriteLine("DoZ");
        }

        public void DoW(A1Request request)
        {
            Console.WriteLine("DoW");
        }
    }
}