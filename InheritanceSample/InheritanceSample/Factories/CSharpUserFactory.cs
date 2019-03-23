using System;

namespace InheritanceSample.Factories
{
    public class CSharpUserFactory : UserFactory, ICSharpUserFactory
    {
        public void Update()
        {
            Console.WriteLine("CSharpUserFactory Update");
        }
    }
}