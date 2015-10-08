﻿using ChattyApp.Duplex;
using ChattyApp.RequestReply;
using ChattyDomain;
using System;
using System.ServiceModel;

namespace ChattyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var message = "Random number is " + random.Next(1, 1001);

            SendMessage(message);
            Console.WriteLine("SendMessage has done");

            SendMessageWithCallback(message);
            Console.WriteLine("SendMessageWithCallback has done");

            Console.ReadLine();
        }

        static void SendMessage(string message)
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

                var messageDto = new MessageDto()
                {
                    Message = message,
                    SentAt = DateTime.Now
                };

                proxy.SendMessage(messageDto);
                proxy.LogMessage(messageDto);

                proxy.Close();
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

        static void SendMessageWithCallback(string message)
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

                var messageDto = new MessageDto()
                {
                    Message = message,
                    SentAt = DateTime.Now
                };

                proxy.LogMessage(messageDto);
                proxy.SendMessage(messageDto);

                proxy.Close();
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
