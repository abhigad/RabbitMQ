using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RabbitMQ.ServiceModel;
using RabbitMQ.Client;
using RabbitMQ.Util;

namespace ReadAMQPMessage
    {
 
    public class Service1 : IService1
        {
        public string ReadMessage()
            {
            RabbitMQ.ServiceModel.RabbitMQBindingSection binding = new RabbitMQBindingSection();
            

            
            return null;
            }
        }
    }

