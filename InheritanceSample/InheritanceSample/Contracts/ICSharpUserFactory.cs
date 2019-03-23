using InheritanceSample.Contracts;

namespace InheritanceSample.Factories
{
    public interface ICSharpUserFactory : IBaseUserFactory
    {
        void Update();
    }
}