using ChattyDomain;
using ClientToSelfHost.Duplex;
using ClientToSelfHost.RequestReply;
using Rabbit.Communication;
using System;
using System.Linq;
using System.ServiceModel;

namespace ClientToSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessService0();

            AccessService1();

            Console.WriteLine("Enter to continue service 2");
            Console.ReadLine();

            AccessService2();

            Console.ReadLine();
        }

        static void AccessService0()
        {
            try
            {
                var proxy = new MessageServiceClient();
                proxy.SetUserNameAndPassword("hhoangvan1", "hhoangvan1");

                var token = proxy.AuthorizeClient();
                Console.WriteLine("Token " + token);
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

        static void AccessService1()
        {
            try
            {
                var proxy = new MessageServiceClient();
                proxy.SetUserNameAndPassword("hhoangvan", "hhoangvan");

                var message = new MessageDto()
                {
                    Message = "Hello request/reply"
                };

                proxy.SendMessage(message);
                proxy.LogMessage(message);

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
                proxy.SetUserNameAndPassword("hhoangvan", "hhoangvan");

                var message = new MessageDto()
                {
                    Message = "Hello duplex"
                };
                proxy.SendMessage(message);
                proxy.LogMessage(message);

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
