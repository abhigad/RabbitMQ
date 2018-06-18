using System;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQSender
    {
    class Program
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Start Sending Message");

            //Console.WriteLine("[X] Message {0} sent to RabbitMQ", SendMessage.SendRabbitMQMessage("1224"));

            SendMessage.GetAllMessages();

            Console.WriteLine(" Press [enter MAIN] to exit.");

            Console.ReadLine();
            }

        }
    }
