namespace Demo.ServiceBusQueue.WebJobs.SharedLibrary.Model
{
    public class Message
    {
        public MessageControl Control { get; set; }
        public MessagePayload Payload { get; set; }
    }
}
