using System.ServiceModel;
using ChattyDomain;

namespace ChattyServer
{
    public interface IMessageServiceCallback
    {
        [OperationContract]
        void NotifyMessage(MessageDto message);
    }
}