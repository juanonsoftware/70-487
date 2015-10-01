using ChattyDomain;
using System.ServiceModel;

namespace ChattyServices
{
    public interface IMessageServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyMessage(MessageDto message);
    }
}