using System;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using Pinnacle.ResponsibleGaming.Events;
using Pinnacle.ResponsibleGaming.Infrastructure.Hubs;
using Pinnacle.ResponsibleGaming.Infrastructure.Repositories;

namespace Pinnacle.ResponsibleGaming.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = new RabbitHub())
            {
                using (var context = new MainContext())
                {
                    var limitRepository = new LimitRepository(context);
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
}
