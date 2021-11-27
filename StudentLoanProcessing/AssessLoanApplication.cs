using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentLoanProcessing.Models;

namespace StudentLoanProcessing
{
    public static class AssessLoanApplication
    {
      
            [FunctionName("AssessLoanApplication")]
            public static void Run([BlobTrigger("submitted-loanapplication/{name}", Connection = "")] string loanApplicationJson, string name, ILogger log)
            {
                LoanApplication loanApplication = JsonConvert.DeserializeObject<LoanApplication>(loanApplicationJson);
                log.LogInformation($"ProcessLoanApplication Blob Trigger for \n Name:{loanApplication.FirstName + " " + loanApplication.LastName}");
            }
     
    }
}
