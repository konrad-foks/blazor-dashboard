using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models.Messages
{
    public class CounterMessage : IMessage
    {
        public string Source { get; set; }

        public DateTime Date { get; set; }

        public int Counter { get; set; }
    }
}
