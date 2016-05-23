using ServiceStack.ServiceHost;

namespace ServiceStack3x_01.RequestDTO
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello
    {
        public string Name { get; set; }
    }
}