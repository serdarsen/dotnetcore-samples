using System;
using InheritanceSample.Contracts;

namespace InheritanceSample.Factories
{
    public class BaseUserFactory : IBaseUserFactory
    {
        public bool Create()
        {
            Console.WriteLine("Create");

            return true;
        }

        public bool Delete()
        {
            Console.WriteLine("Delete");

            return true;
        }
    }
}
