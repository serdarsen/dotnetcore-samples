using InterceptorSample.Requests;

namespace InterceptorSample.Services
{
    public interface IXService
    {
        void DoX(ARequest request);
        void DoY(BRequest request);
        void DoZ(OtherRequest request);
        void DoW(A1Request request);
    }
}