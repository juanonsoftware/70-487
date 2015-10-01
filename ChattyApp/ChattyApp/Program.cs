using ChattyApp.ChattyServer;
using System;

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
                var proxy = new MessageServiceClient();

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
