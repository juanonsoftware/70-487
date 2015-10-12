using ChattyServices;
using System;
using System.Security.Principal;
using System.ServiceModel;

namespace ChattyServerSelfHost
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Create a ServiceHost for the CalculatorService type and provide the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(MessageService));
            ServiceHost serviceHost2 = new ServiceHost(typeof(DuplexMessageService));
            {
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                serviceHost2.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}