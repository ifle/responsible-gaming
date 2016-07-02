using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Loggers;
using EasyNetQ.Topology;
using Pinnacle.ResponsibleGaming.Events;
using Pinnacle.ResponsibleGaming.Read.Updaters;

namespace Pinnacle.ResponsibleGaming.Bus
{
    public class Bus
    {
        private IBus _bus;
        private readonly LogUpdater _logUpdater;

        public Bus(LogUpdater logUpdater)
        {
            _logUpdater = logUpdater;
        }

        private void Initialize()
        {
            const string rabbitMqConnectionString = "host=172.24.20.224;username=soccertrader;password=testtest";
            _bus = RabbitHutch.CreateBus(rabbitMqConnectionString,
                conventions => conventions
                    .Register<IEasyNetQLogger>(_ => new NullLogger())); //adds custom exchange prefix
        }

        public async void Publish<T>(T @event) where T : class
        {
            var exchange = await _bus.Advanced.ExchangeDeclareAsync("someExchangeName", ExchangeType.Fanout);
            var queue = await _bus.Advanced.QueueDeclareAsync("someQueueName");
            var routingKey = string.Empty; //fanout
            await _bus.Advanced.BindAsync(exchange, queue, routingKey);

            //Publisher
            await _bus.Advanced.PublishAsync(exchange, routingKey, false, new Message<T>(@event));

        }

        private async void Subscribe()
        {
            var queue = await _bus.Advanced.QueueDeclareAsync("someQueueName");

            //Subscriber
            _bus.Advanced.Consume(queue, x => x
                .Add<DepositLimitSet>((message, info) =>
                    {
                        _logUpdater.Update(message.Body);
                    })
                .Add<DepositLimitDisabled>((message, info) =>
                    {
                        _logUpdater.Update(message.Body);
                    })
             );
        }
    }
}
