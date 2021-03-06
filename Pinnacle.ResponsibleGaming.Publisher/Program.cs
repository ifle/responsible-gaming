﻿using System;
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
            Console.WriteLine("Publisher is listenting...");
            Console.WriteLine();
            while (true)
            {
                using (var context = new MainContext())
                {
                    using (var rabbitHub = new RabbitHub())
                    {
                        var events = context.Events.Where(x => x.Sent == false).OrderBy(x => x.EventId).ToList();
                        foreach (var @event in events)
                        {
                            rabbitHub.Publish(@event.ToLimitSet());
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
