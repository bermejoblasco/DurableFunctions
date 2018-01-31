
namespace RodolfoDAF
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;

    public static class RodolfoSay
    {
        [FunctionName("RodolfoSay")]
        public static async Task Run(
            [OrchestrationTrigger] DurableOrchestrationContext context,
            TraceWriter log)
        {  
            var execute = await context.CallActivityAsync<string>("RodolfoExecute", "Hola");
            log.Info(execute);

            execute = await context.CallActivityAsync<string>("RodolfoExecute", "Soy Rodolfo");
            log.Info(execute);

            execute = await context.CallActivityAsync<string>("RodolfoExecute", "¿A que molo?");
            log.Info(execute);
        }

        [FunctionName("RodolfoExecute")]
        public static string RodolfoExecute([ActivityTrigger] string phrase)
        {
            return $"Rodolfo say: {phrase}!";
        }
    }
 }
