using Funq;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Testing;
using ServiceStack.Text;
using ServiceStack3x_01.Biz;
using ServiceStack3x_01.Services;
using Xunit;
using Xunit.Abstractions;

namespace api.tests.Services
{
    public class HelloServiceTest
    {
        private readonly Container _container;
        private readonly ITestOutputHelper _output;

        public HelloServiceTest(ITestOutputHelper output)
        {
            this._output = output;

            _container = new Container();

            // Register your own dependencies
            _container.RegisterAutoWiredAs<HelloBiz, IHelloBiz>().ReusedWithin(Funq.ReuseScope.Container);

            // Register the Service so new instances are autowired with your dependencies
            _container.RegisterAutoWired<HelloService>();
        }

        [Fact]
        public void TestHello()
        {
            var service = _container.Resolve<HelloService>();
            service.SetResolver(new BasicResolver(_container));

            const string name = "Tom";
            var result = service.Any(new ServiceStack3x_01.RequestDTO.Hello()
            {
                Name = name
            });

            _output.WriteLine("result:");
            _output.WriteLine(result.Dump());

            Assert.NotNull(result);
            Assert.Equal($"Hello, {name}", result.Result);
        }

        [Fact]
        public void TestHello2()
        {
            var service = _container.Resolve<HelloService>();
            service.SetResolver(new BasicResolver(_container));

            Assert.Throws<ServiceResponseException>(() =>
            {
                const string name = "Tomex";
                var result = service.Any(new ServiceStack3x_01.RequestDTO.Hello()
                {
                    Name = name
                });

                _output.WriteLine("result:");
                _output.WriteLine(result.Dump());
            });
        }
    }
}