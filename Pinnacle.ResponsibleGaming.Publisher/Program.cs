using System;
using System.Linq;
using System.Threading;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using Pinnacle.ResponsibleGaming.Infrastructure.Hubs;

namespace Pinnacle.ResponsibleGaming.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                using (var rabbitHub = new RabbitHub())
                {

                    Console.WriteLine("Listenting...");
                    Console.WriteLine();
                    while (true)
                    {
                        var events = context.Events.Where(x => x.Sent == false).ToList();
                        foreach (var @event in events)
                        {
                            rabbitHub.Publish(@event);
                            @event.Sent = true;
                            context.SaveChanges();
                            Console.Write("Event published!");
                            Console.WriteLine();
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
}
