using ChattyDomain;
using System;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace ChattyServices
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public class DuplexMessageService : IDuplexMessageService
    {
        private readonly MessageRepository _messageRepository;
        private IMessageServiceCallback _serviceCallback;

        public DuplexMessageService()
        {
            _messageRepository = new MessageRepository();
        }

        public void SendMessage(MessageDto message)
        {
            if (ServiceCallback != null)
            {
                ServiceCallback.NotifyMessage(message);
            }
        }

        public void LogMessage(MessageDto message)
        {
            _messageRepository.Add(message);

            // Simulate processing time
            Thread.Sleep(new Random().Next(100, 1001));
        }

        public MessageDto[] GetAll()
        {
            return _messageRepository.GetAll().ToArray();
        }

        public IMessageServiceCallback ServiceCallback
        {
            get
            {
                return _serviceCallback ??
                       (_serviceCallback = OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>());
            }
        }
    }
}