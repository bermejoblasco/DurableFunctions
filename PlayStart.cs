namespace RodolfoDAF
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using System.Threading.Tasks;

    public static class PlayStart
    {
        [FunctionName("PlayStart")]
        public static async Task Run(
            [QueueTrigger("rodolfoqueue")] string functionName,
            [OrchestrationClient] DurableOrchestrationClient starter,
            TraceWriter log)
        {
            string instanceId = await starter.StartNewAsync(functionName, null);

            log.Info($"Started orchestration with ID = '{instanceId}'.");              
        }
    }
}