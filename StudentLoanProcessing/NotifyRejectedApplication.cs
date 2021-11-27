using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentLoanProcessing.Models;

namespace StudentLoanProcessing
{
    public static class NotifyRejectedApplication
    {
        [FunctionName("NotifyRejectedApplication")]
        public static void Run([BlobTrigger("rejected-application/{name}", Connection = "")] string loanApplicationJson,
        string name, ILogger log)
        {
            LoanApplication loanApplication = JsonConvert.DeserializeObject<LoanApplication>(loanApplicationJson);
            log.LogInformation($"ProcessRejectedLoanApplication Blob Trigger for \n Name:{loanApplication.FirstName + " " + loanApplication.LastName}");
        }
    }
}
