using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models.Messages
{
    public interface IMessage
    {
        string Source { get; }
        DateTime Date { get; }
    }
}
