using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationClient
{
    public class MessageItem
    {
        public string SenderName { get; set; }
        public string SenderIp { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public MessageItem(string message, string senderIp = null, string senderName = null)
        {
            this.Message = message;
            this.SenderName = senderName;
            this.SenderIp = senderIp;
            this.CreatedAt = DateTime.Now;
        }
        
    }
}
