using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramSimpleBot.Models
{
    public class ActionUser
    {
        public string Name { get; set; }

        public bool? isComplete { get; set; }
        
        public bool? isConfirm { get; set; }
    }
}