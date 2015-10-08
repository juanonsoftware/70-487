using ChattyDomain;
using System.ServiceModel;

namespace ChattyServices
{
    [ServiceContract(CallbackContract = typeof(IMessageServiceCallback))]
    public interface IDuplexMessageService
    {
        /// <summary>
        /// Send a message to partner
        /// </summary>
        [OperationContract]
        void SendMessage(MessageDto message);

        /// <summary>
        /// Log messages for history
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void LogMessage(MessageDto message);

        [OperationContract]
        MessageDto[] GetAll();
    }
}
