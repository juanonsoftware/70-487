using ChattyDomain;
using System.ServiceModel;

namespace ChattyServices
{
    public interface IMessageServiceCallback
    {
        [OperationContract(IsOneWay = false)]
        void NotifyMessage(MessageDto message);
    }
}