using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Loggers;
using EasyNetQ.Topology;
using Pinnacle.ResponsibleGaming.Domain.Events;
using Pinnacle.ResponsibleGaming.Read.Updaters;

namespace Pinnacle.ResponsibleGaming.Bus
{
    public class Bus
    {
        private IBus _bus;
        private IExchange _exchange;
        private IQueue _queue;

        private readonly LogUpdater _logUpdater;

        public Bus(LogUpdater logUpdater)
        {
            _logUpdater = logUpdater;
            Initialize();
        }

        private void Initialize()
        {
            const string rabbitMqConnectionString = "host=weasel.rmq.cloudamqp.com;virtualHost=rwcysecm;username=rwcysecm;password=SBv4_yE-S_GMcAeJjk2iIkBrySy3QoRr";
            _bus = RabbitHutch.CreateBus(rabbitMqConnectionString,
                conventions => conventions
                    .Register<IEasyNetQLogger>(_ => new NullLogger())); //adds custom exchange prefix


            _exchange = _bus.Advanced.ExchangeDeclare("responsible-gaming", ExchangeType.Fanout);
            _queue = _bus.Advanced.QueueDeclare("responsible-gaming # responsible-gaming");
            _bus.Advanced.Bind(_exchange, _queue, "");

            Subscribe();
        }

        public async Task Publish<T>(T @event) where T : class
        {
            await _bus.Advanced.PublishAsync(_exchange, "", false, new Message<T>(@event));
        }

        private void Subscribe()
        {
            _bus.Advanced.Consume(_queue, x => x
                .Add<DepositLimitSet>((message, info) => Task.Run(async () =>
                {
                        await _logUpdater.Update(message.Body);
                }))
                .Add<DepositLimitDisabled>((message, info) => Task.Run(async () =>
                {
                        await _logUpdater.Update(message.Body);
                }))
             );
        }

        public void Dispose()
        {
            _bus.Advanced.Dispose();
        }
    }
}
