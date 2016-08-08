using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.WebJobs;
using System.Configuration;

namespace MessageReceiverWebJob
{
    class Program
    {
        static void Main()
        {
            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["AzureApplicationInsights.InstrumentationKey"];

            JobHostConfiguration config = new JobHostConfiguration();
            config.UseServiceBus();

            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}
