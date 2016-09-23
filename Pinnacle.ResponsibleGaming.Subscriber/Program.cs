using System;
using Pinnacle.ResponsibleGaming.Events;
using Pinnacle.ResponsibleGaming.Infrastructure.Hubs;

namespace Pinnacle.ResponsibleGaming.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = new RabbitHub())
            {
                    Console.WriteLine("Subscriber is listenting...");
                    Console.WriteLine();
                    bus.Consume( x => x
                        .Add<LimitSet>((message, info) =>
                        {
                           Handler.Handle(message.Body);
                        })
                        .ThrowOnNoMatchingHandler = false
                        );
                    Console.ReadKey();
            }          
        }
    }
}
