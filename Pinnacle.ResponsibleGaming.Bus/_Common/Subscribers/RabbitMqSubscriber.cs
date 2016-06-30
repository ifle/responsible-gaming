using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Pinnacle.ResponsibleGaming.Bus._Common.Subscribers
{
    public class RabbitMqSubscriber
    {
        private  readonly ConnectionFactory _connFactory;

        // CloudAMQP URL in format amqp://user:pass@hostName:port/vhost
        public RabbitMqSubscriber(string  amqpUrl)
        {
            _connFactory = new ConnectionFactory() {Uri = amqpUrl};
        }

        public void  Subscribe<T>() where T:class
        {
            using (var conn = _connFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                const string queueName = "responsible-gaming # responsible-gaming";
                const string exchangeName = "responsible-gaming";

                channel.ExchangeDeclare(exchange: exchangeName, type: "fanout");
                channel.QueueBind(queue: queueName,
                                  exchange: exchangeName,
                                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);
                };
                channel.BasicConsume(queue: queueName,
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
