using BlazorApp1.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class MessageService : IMessageService
    {
        Subject<IMessage> subject = new Subject<IMessage>();

        public IObservable<IMessage> Messages => subject.AsObservable();

        public void Publish(IMessage message)
        {
            subject.OnNext(message);
        }
    }
}
