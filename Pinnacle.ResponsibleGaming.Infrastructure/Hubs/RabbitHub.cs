using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Loggers;
using EasyNetQ.Topology;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Hubs
{
    public class RabbitHub
    {
        private IBus _bus;
        private IExchange _exchange;

        public RabbitHub()
        {
            Initialize();
        }

        private void Initialize()
        {
            const string rabbitMqConnectionString = "host=weasel.rmq.cloudamqp.com;virtualHost=rwcysecm;username=rwcysecm;password=SBv4_yE-S_GMcAeJjk2iIkBrySy3QoRr";
            _bus = RabbitHutch.CreateBus(rabbitMqConnectionString,
                conventions => conventions
                    .Register<IEasyNetQLogger>(_ => new NullLogger())); //adds custom exchange prefix

            _exchange = _bus.Advanced.ExchangeDeclare("responsible-gaming", ExchangeType.Fanout);

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