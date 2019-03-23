using System;

namespace InheritanceSample.Factories
{
    public class UserFactory : IUserFactory
    {
        public bool Create()
        {
            Console.WriteLine("UserFactory Create");

            return true;
        }

        public bool Delete()
        {
            Console.WriteLine("UserFactory Delete");

            return true;
        }
    }
}
