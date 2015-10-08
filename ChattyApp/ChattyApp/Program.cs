using ChattyApp.ChattyServer;
using ChattyDomain;
using System;
using System.ServiceModel;

namespace ChattyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            var random = new Random();

            while (true)
            {
                if (count > 100)
                {
                    break;
                }
                count += 1;

                Console.WriteLine("Enter to send a message #" + count);
                Console.ReadLine();

                var message = "Random number is " + random.Next(1, 1001);
                try
                {
                    SendMessage(message);
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

        static void SendMessage(string message)
        {
            var context = new InstanceContext(new MessageServiceCallback());
            var proxy = new MessageServiceClient(context);
            if (proxy.ClientCredentials == null)
            {
                throw new ApplicationException("proxy.ClientCredentials is null");
            }

            proxy.ClientCredentials.UserName.UserName = "hhoangvan";
            proxy.ClientCredentials.UserName.Password = "abcdef";

            var messageDto = new MessageDto()
            {
                Message = message,
                SentAt = DateTime.Now
            };

            proxy.LogMessage(messageDto);
            proxy.SendMessage(messageDto);

            proxy.Close();
        }
    }
}
