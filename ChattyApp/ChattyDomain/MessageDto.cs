using System;
using System.Runtime.Serialization;

namespace ChattyDomain
{
    [DataContract]
    public class MessageDto
    {
        [DataMember]
        public DateTime SentAt { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}