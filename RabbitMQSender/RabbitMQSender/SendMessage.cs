using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQSender
    {
    internal class SendMessage
        {
        public static readonly string uri = "amqp:";

        public static string SendRabbitMQMessage(string message = "empty message")
            {
            var factory = new ConnectionFactory()
                {
                Uri = new Uri(uri)
                };

            using (var connection = factory.CreateConnection())
                {
                using (var channel = connection.CreateModel())
                    {
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);

                    return message;
                    }
                }
            }

        public static void Test()
            {
            var factory = new ConnectionFactory()
                {
                Uri = new Uri(uri)
                };

            using (var connection = factory.CreateConnection())
                {
                using (var channel = connection.CreateModel())
                    {
                    //false : keep message ;true : read and remove it
                    var v = channel.BasicGet("hello", true);

                    Console.WriteLine(" Messgae Received {0}", Encoding.UTF8.GetString(v.Body));
                    }
                }
            }

        public static void GetAllMessages()
            {
            var factory = new ConnectionFactory()
                {
                Uri = new Uri(uri)
                };

            using (var connection = factory.CreateConnection())
                {
                using (var channel = connection.CreateModel())
                    {
                    channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                    string queueName = channel.QueueDeclare();

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };

                    channel.BasicConsume(queue: "hello",
                                         autoAck: false,
                                         consumer: consumer);

                    //blocking transaction
                    Console.WriteLine(" Press [enter Receiver] to exit.");
                    Console.ReadLine();

                    }
                }

            }

        }
    }

