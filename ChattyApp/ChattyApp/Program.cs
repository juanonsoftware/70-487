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
                var context = new InstanceContext(new MessageServiceCallback());
                var proxy = new MessageServiceClient(context);

                var messageDto = new MessageDto()
                {
                    Message = message,
                    SentAt = DateTime.Now
                };

                proxy.LogMessage(messageDto);
                proxy.SendMessage(messageDto);
            }
        }
    }
}
