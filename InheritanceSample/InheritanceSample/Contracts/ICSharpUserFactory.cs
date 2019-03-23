using InheritanceSample.Contracts;

namespace InheritanceSample.Factories
{
    public interface ICSharpUserFactory : IUserFactory
    {
        void Update();
    }
}