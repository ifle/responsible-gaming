using System;
using System.Linq;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using EasyNetQ;
using Pinnacle.ResponsibleGaming.Events;

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
                using (var context = new ResponsibleGamingContext())
                {
                    bus.Advanced.Consume(queue, x => x
                        .Add<LimitSet>((message, info) =>
                        {
                            Console.WriteLine("Limit set for {0}", message.Body.CustomerId);
                        })
                    );

                }
            }          
        }
    }
}
