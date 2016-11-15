using System;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                        
            client.Login(777);
            client.Confirm();
            client.GetDataUsingDataContract(6665);
            

            Console.WriteLine("ok");
            Console.ReadKey(true);

        }
    }
}
