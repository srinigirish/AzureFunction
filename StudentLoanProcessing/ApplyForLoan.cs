using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentLoanProcessing.Models;

namespace StudentLoanProcessing
{
    public static class ApplyForLoan
    {
        /// <summary>
        /// HttpTrigger accepts both get and post if only one of them is to be supported then remove the other attribute
        /// Queue attribute allows message/payload to be placed in AzureQueue storage.
        /// In the example below name of the queue is "loanApplication"
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("ApplyForLoan")]
        //[return:Queue("loanApplication")]
        public static async Task<LoanApplication> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Queue("loanApplication")] IAsyncCollector<LoanApplication> applicationQueue,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            LoanApplication data = JsonConvert.DeserializeObject<LoanApplication>(requestBody);
            log.LogInformation($"Received Credit Card Application from : {data.FirstName + " " + data.LastName }");
            await applicationQueue.AddAsync(data);
            return data;
        }
    }
}
