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
            var context = new Context();
            var rabbitHub = new RabbitHub();

            Console.WriteLine("Listenting...");
            Console.WriteLine();
                while (true)
                {
                    var events = context.Events.Where(x => x.Sent == false).ToList();
                    foreach (var @event in events)
                    {
                        rabbitHub.Publish(@event);
                        Console.Write("Event published!" + " (" + @event.Name + ")");
                        Console.WriteLine();
                        @event.Sent = true;
                        context.SaveChanges();
                    }
                    Thread.Sleep(1000);
                }
        }
    }
}
