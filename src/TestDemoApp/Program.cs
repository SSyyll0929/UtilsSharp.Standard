using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDemoApp.ElasticSearch;
using TestDemoApp.Kafka;
using TestDemoApp.RabbitMQ;

namespace TestDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ElasticSearchInit.Init();
            Console.ReadKey();


            //new KafkaInit();
            //Console.ReadKey();

            //RabbitMqInit.Init();

            //RabbitMqInit.SendMessage();

            //RabbitMqInit.GetMessage();

            //Console.ReadKey();
        }

    }
}
