﻿using ChattyApp.Duplex;
using ChattyDomain;
using System;

namespace ChattyApp
{
    public class MessageServiceCallback : IDuplexMessageServiceCallback
    {
        public void NotifyMessage(MessageDto message)
        {
            Console.WriteLine("{0} at {1}", message.Message, message.SentAt);
        }
    }
}