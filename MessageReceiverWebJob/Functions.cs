using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.ServiceBus.Messaging;
using Demo.ServiceBusQueue.WebJobs.SharedLibrary.Model;
using System.Threading;
using System;
using Microsoft.ApplicationInsights;

namespace MessageReceiverWebJob
{
    public class Functions
    {
        // The SDK receives a message in PeekLock mode and calls Complete on the message
        // if the function finishes successfully, or calls Abandon if the function fails.
        // If the function runs longer than the PeekLock timeout, the lock is automatically renewed.
        public static void HandleQueueMessage([ServiceBusTrigger("demoqueue")] BrokeredMessage message,
            TextWriter logger)
        {
            var start = DateTime.Now;
            var msgControl = message.GetBody<MessageControl>();

            logger.WriteLine("Machine Name: {0}, Managed Thread ID: {1}", Environment.MachineName, Thread.CurrentThread.ManagedThreadId);
            logger.WriteLine("Queue message received: {0}", message.MessageId);
            logger.WriteLine("Message Reference ID: {0}", msgControl.ReferenceID);

            #region Application Insights
            var timeDuration = DateTime.Now - start;
            var tc = new TelemetryClient();
            tc.TrackRequest("HandleQueueMessage", DateTimeOffset.UtcNow, timeDuration, "200", true);

            // track the machine name that processed the messsage
            tc.TrackEvent(Environment.MachineName);
            tc.Flush();  // ensure that the event is flushed to AI
            #endregion
        }
    }
}
