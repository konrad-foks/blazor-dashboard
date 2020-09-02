using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models.Messages
{
    public class ErrorMessage : IMessage
    {
        public string Source { get; set; }

        public DateTime Date { get; set; }

        public string Error { get; set; }
    }
}
