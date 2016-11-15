namespace TestWcfRestrict
{
    public class ExternalService : IExternalService
    {
        public string Method1(int input)
        {
            return "r" + input;
        }
    }
}