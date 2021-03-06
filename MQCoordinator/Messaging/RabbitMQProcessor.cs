﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQCoordinator.Plugins.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MQCoordinator.Messaging
{
    public class RabbitMQProcessor
    {
        public static void Enqueue(ExampleMessage message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "VehicleQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message.BodyText);

                channel.BasicPublish(exchange: "",
                                     routingKey: "VehicleQueue",
                                     basicProperties: null,
                                     body: body);
            }
        }

        public static void HandleQueueItems()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "VehicleQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    PluginManager.HandleMessageForLoadedPlugins(new ExampleMessage { BodyText = message });
                };
                channel.BasicConsume(queue: "VehicleQueue",
                                     noAck: true,
                                     consumer: consumer);
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }
        }
    }
}
