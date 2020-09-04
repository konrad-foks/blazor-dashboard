using BlazorApp1.Models.Messages;
using BlazorApp1.Services;
using Bogus;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public class MessagesGeneratorBackgroundService : IHostedService
    {
        readonly IMessageService messageService;
        IDisposable subscriber1;
        IDisposable subscriber2;

        public MessagesGeneratorBackgroundService(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var sources = new string[] { "A", "B", "C" };
            var faker = new Faker();

            subscriber1 = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Subscribe(x =>
                {
                    messageService.Publish(new CounterMessage
                    {
                        Counter = DateTime.Now.Second,
                        Source = faker.Random.ArrayElement(sources),
                        Date = DateTime.Now
                    });
                });

            subscriber2 = Observable
                .Interval(TimeSpan.FromSeconds(2))
                .Subscribe(x =>
                {
                    messageService.Publish(new ErrorMessage
                    {
                        Error = faker.Lorem.Lines(1),
                        Source = faker.Random.ArrayElement(sources),
                        Date = DateTime.Now
                    });
                });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            subscriber1?.Dispose();
            subscriber2?.Dispose();
        }
    }
}
