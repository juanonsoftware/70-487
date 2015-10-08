using ClientToSelfHost.Duplex;
using ClientToSelfHost.RequestReply;
using System;
using System.Linq;
using System.ServiceModel;

namespace ClientToSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessService1();

            Console.WriteLine("Enter to continue service 2");
            Console.ReadLine();

            AccessService2();

            Console.ReadLine();
        }

        static void AccessService1()
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
        }

        static void AccessService2()
        {
            try
            {
                var context = new InstanceContext(new MessageServiceCallback());
                var proxy = new DuplexMessageServiceClient(context);
                if (proxy.ClientCredentials == null)
                {
                    return;
                }

                proxy.ClientCredentials.UserName.UserName = "hhoangvan";
                proxy.ClientCredentials.UserName.Password = "hhoangvan";

                proxy.SendMessage(new Duplex.MessageDto()
                {
                    Message = "Hello"
                });

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
        }
    }
}
