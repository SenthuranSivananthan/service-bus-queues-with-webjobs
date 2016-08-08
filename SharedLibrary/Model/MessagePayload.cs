using System;

namespace Demo.ServiceBusQueue.WebJobs.SharedLibrary.Model
{
    [Serializable]
    public class MessagePayload
    {
        public string ReferenceID { get; set; }

        public string PayloadXML { get; set; }
    }
}
