namespace ServiceStack3x_01.Biz
{
    public class HelloBiz : IHelloBiz
    {
        public string Hello(string name)
        {
            return $"Hello, {name}";
        }
    }
}