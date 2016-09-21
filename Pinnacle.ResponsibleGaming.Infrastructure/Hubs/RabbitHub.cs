using System;
using EasyNetQ;
using EasyNetQ.Loggers;
using EasyNetQ.Topology;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Hubs
{
    public class RabbitHub: IDisposable
    {
        private IBus _bus;
        private IExchange _exchange;
        private IQueue _queue;

        public RabbitHub()
        {
            Initialize();
        }

        private void Initialize()
        {
            const string rabbitMqConnectionString = "host=172.24.21.133;virtualHost=Customer;username=CustomerTeam.DefaultUser;password=admin";
            _bus = RabbitHutch.CreateBus(rabbitMqConnectionString,
                conventions => conventions
                    .Register<IEasyNetQLogger>(_ => new NullLogger()));

            _exchange = _bus.Advanced.ExchangeDeclare("responsible-gaming", ExchangeType.Fanout);
            _queue = _bus.Advanced.QueueDeclare("responsible-gaming # responsible-gaming");
            _bus.Advanced.Bind(_exchange, _queue, string.Empty);
        }

        public void Publish<T>(T @event) where T : class
        {
            _bus.Advanced.Publish(_exchange, "", false, new Message<T>(@event));
        }

        public void Dispose()
        {
            _bus.Advanced.Dispose();
        }
    }
}