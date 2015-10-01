using System;
using System.Runtime.Serialization;

namespace ChattyDomain
{
    [DataContract]
    public class MessageDto
    {
        public MessageDto()
        {
            Id = Guid.NewGuid();
        }

        [DataMember]
        public Guid Id
        {
            get;
            private set;
        }

        [DataMember]
        public DateTime SentAt { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}