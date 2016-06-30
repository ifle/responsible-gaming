using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Pinnacle.ResponsibleGaming.Bus._Common.Publishers
{
    public class RabbitMqPublisher
    {
        private readonly ConnectionFactory _connFactory;

        // CloudAMQP URL in format amqp://user:pass@hostName:port/vhost
        public  RabbitMqPublisher(string  amqpUrl)
        {
            _connFactory = new ConnectionFactory() {Uri = amqpUrl};
        }

        public void  Publish(object @event)
        {
            using (var conn = _connFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var message = JsonConvert.SerializeObject(@event);
                var data = Encoding.UTF8.GetBytes(message);
                const string exchangeName = "responsible-gaming";
                const string routingKey = "";
                var props = channel.CreateBasicProperties();
                props.Headers = new Dictionary<string, object> {{"Type", @event.GetType().Name}};
                channel.BasicPublish(exchangeName, routingKey, props, data);
            }
        }
    }
}
