using System.Collections.Generic;
using ChattyDomain;

namespace ChattyServer
{
    public class MessageRepository
    {
        private static readonly IList<MessageDto> Messages = new List<MessageDto>();

        public void Add(MessageDto message)
        {
            Messages.Add(message);
        }

        public IList<MessageDto> GetAll()
        {
            return Messages;
        }
    }
}