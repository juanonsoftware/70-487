using System.ServiceModel;
using ChattyDomain;

namespace ChattyServer
{
    [ServiceContract(CallbackContract = typeof(MessageServiceCallback))]
    public interface IMessageService
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
