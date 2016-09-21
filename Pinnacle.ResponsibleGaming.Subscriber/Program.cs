using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using EasyNetQ;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Events;
using Pinnacle.ResponsibleGaming.Infrastructure.Repositories;

namespace Pinnacle.ResponsibleGaming.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            const string rabbitMqConnectionString = "host=172.24.21.133;virtualHost=Customer;username=CustomerTeam.DefaultUser;password=admin";

            using (var bus = RabbitHutch.CreateBus(rabbitMqConnectionString))
            {
                var queue = bus.Advanced.QueueDeclare("responsible-gaming # responsible-gaming");
                using (var context = new MainContext())
                {
                    var limitRepository = new LimitRepository(context);
                    Console.WriteLine("Subscriber is listenting...");
                    Console.WriteLine();
                    bus.Advanced.Consume(queue, x => x
                        .Add<LimitSet>((message, info) =>
                        {
                            var @event = message.Body;
                            var limit =  limitRepository.Get(@event.CustomerId,(Domain.Entities.LimitType) @event.LimitType).Result;
                            if (limit == null) limit = new Limit();
                            limit.ApplyEvent(@event);
                            context.Limits.AddOrUpdate(limit);
                            context.SaveChanges();
                            Console.WriteLine("Event processed!");
                        })
                        );
                    Console.ReadKey();
                }
            }          
        }
    }
}
