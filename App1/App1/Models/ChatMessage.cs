using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class ChatMessage
    {
        public string Text { get; set; }
        public string User { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
