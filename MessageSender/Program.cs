using Demo.ServiceBusQueue.WebJobs.SharedLibrary.Model;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Configuration;
using System.Threading;

namespace MessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueClient = QueueClient.CreateFromConnectionString(ConfigurationManager.AppSettings["ServiceBusQueue.ConnectionString"]);

            var random = new Random();
            var referenceIdCounter = 1;

            while (true)
            {
                var message = PrepareOutgoingMessage(referenceIdCounter);
                queueClient.Send(message);
                Console.WriteLine(string.Format("Message Sent: {0}", message.MessageId));

                referenceIdCounter++;

                Thread.Sleep(random.Next(100, 500));
            }
        }

        private static BrokeredMessage PrepareOutgoingMessage(int referenceID)
        {
            var ctrlMessage = new MessageControl
            {
                ReferenceID = string.Format("{0:#}", referenceID),
                PayloadLocation = "https://blah.com"
            };

            return new BrokeredMessage(ctrlMessage) { ContentType = "text/plain" };
        }
    }
}
