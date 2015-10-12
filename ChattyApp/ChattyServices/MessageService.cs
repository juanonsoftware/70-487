using ChattyDomain;
using System;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Threading;

namespace ChattyServices
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class MessageService : IMessageService
    {
        private readonly MessageRepository _messageRepository;

        public MessageService()
        {
            _messageRepository = new MessageRepository();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        public string AuthorizeClient()
        {
            return Guid.NewGuid().ToString();
        }

        public void SendMessage(MessageDto message)
        {
        }

        public void LogMessage(MessageDto message)
        {
            _messageRepository.Add(message);

            // Simulate processing time
            Thread.Sleep(new Random().Next(1000, 2001));
        }

        public MessageDto[] GetAll()
        {
            return _messageRepository.GetAll().ToArray();
        }
    }
}