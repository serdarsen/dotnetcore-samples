using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceSample.Factories
{
    public class TranslationBookFactory : ITranslationBookFactory
    {
        public void ITranslationBookFactoryMethod_1()
        {
            Console.WriteLine("ITranslationBookFactoryMethod_1 working");
        }

        public void ITranslationBookFactoryMethod_2()
        {
            Console.WriteLine("ITranslationBookFactoryMethod_2 working");
        }

        public void ITranslationBookFactoryMethod_3()
        {
            Console.WriteLine("ITranslationBookFactoryMethod_3 working");
        }
    }
}
