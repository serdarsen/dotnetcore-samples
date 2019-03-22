using InheritanceSample.Factories;

namespace InheritanceSample.Services
{
    public class TranslationBookService : BaseBookService
    {
        private readonly TranslationBookFactory _translationBookFactory;

        public TranslationBookService(TranslationBookFactory translationBookFactory)
        {
            _translationBookFactory = translationBookFactory;
        }

        public void TestFactoryMethod_1()
        {
            _translationBookFactory.ITranslationBookFactoryMethod_1();
        }
    }
}
