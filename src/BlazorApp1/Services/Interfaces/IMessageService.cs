using BlazorApp1.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public interface IMessageService
    {
        void Publish(IMessage message);

        IObservable<IMessage> Messages { get; }
    }
}
