using System;

namespace Demo.ServiceBusQueue.WebJobs.SharedLibrary.Model
{
    [Serializable]
    public class MessageControl
    {
        public string ReferenceID { get; set; }
        public string PayloadLocation { get; set; }
    }
}
