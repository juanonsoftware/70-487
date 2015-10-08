using System;
using System.Linq;
using ClientToSelfHost.ServiceReference1;

namespace ClientToSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var proxy = new MessageServiceClient();
                if (proxy.ClientCredentials == null)
                {
                    return;
                }

                proxy.ClientCredentials.UserName.UserName = "hhoangvan";
                proxy.ClientCredentials.UserName.Password = "hhoangvan";

                var result = proxy.GetAll();
                Console.WriteLine("Results: " + result.Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----");

                while (ex != null)
                {
                    Console.WriteLine(ex.Message);
                    ex = ex.InnerException;
                }

                Console.WriteLine("-----");
            }

            Console.ReadLine();
        }
    }
}
