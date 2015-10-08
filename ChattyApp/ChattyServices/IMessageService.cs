using ChattyDomain;
using System.ServiceModel;

namespace ChattyServices
{
    [ServiceContract]
    public interface IMessageService
    {
        /// <summary>
        /// Authorizes client and returns a token key
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string AuthorizeClient();

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
