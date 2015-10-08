using System;
using System.ServiceModel;

namespace Rabbit.Communication
{
    public static class CommunicationObjectExtensions
    {
        public static void SetUserNameAndPassword<TChannel>(this ClientBase<TChannel> client,
            string userName,
            string password) where TChannel : class
        {
            if (client.ClientCredentials == null)
            {
                throw new InvalidOperationException("ClientCredentials is null");
            }

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;
        }
    }
}
