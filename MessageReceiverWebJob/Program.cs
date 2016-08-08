using Microsoft.Azure.WebJobs;

namespace MessageReceiverWebJob
{
    class Program
    {
        static void Main()
        {
            JobHostConfiguration config = new JobHostConfiguration();
            config.UseServiceBus();

            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}
