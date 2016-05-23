using ServiceStack.ServiceInterface;
using ServiceStack3x_01.Biz;
using ServiceStack3x_01.RequestDTO;
using ServiceStack3x_01.ResponseDTO;

namespace ServiceStack3x_01.Services
{
    public class HelloService : Service
    {
        private readonly IHelloBiz _helloBiz;

        public HelloService(IHelloBiz helloBiz)
        {
            _helloBiz = helloBiz;
        }

        public object Any(Hello request)
        {
            if (request.Name.Contains("ex"))
            {
                throw new ServiceResponseException("error 123");
            }

            //            return new HelloResponse { Result = $"Hello, {request.Name}" };

            return new HelloResponse { Result = _helloBiz.Hello(request.Name) };
        }
    }
}