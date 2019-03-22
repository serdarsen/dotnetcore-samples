using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceSample.Factories
{
    interface ITranslationBookFactory : IBookFactory
    {
        void ITranslationBookFactoryMethod_1();
        void ITranslationBookFactoryMethod_2();
        void ITranslationBookFactoryMethod_3();
    }
}
