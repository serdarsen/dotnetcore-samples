using System;
using InheritanceSample.Contracts;

namespace InheritanceSample.Factories
{
    public class JavaUserFactory : BaseUserFactory, IJavaUserFactory
    {
        public void Upgrade()
        {
            Console.WriteLine("JavaUserFactory Upgrade");
        }
    }
}