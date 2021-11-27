using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentLoanProcessing.Models;
 

namespace StudentLoanProcessing
{
    public static class FinalizeAcceptedApplication
    {
        [FunctionName("FinalizeAcceptedApplication")]
        public static void Run([QueueTrigger("loanapplication", Connection = "")] LoanApplication loanApplication,
        [Blob("approved-application/{rand-guid}")] out string approvedloanApplication,
        [Blob("rejected-application/{rand-guid}")] out string rejectedloanApplication,
        ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed for : {loanApplication.FirstName + " " + loanApplication.LastName}");

            bool isloanApproved = loanApplication.YearlyIncome > 100000;

            if (isloanApproved)
            {
                approvedloanApplication = JsonConvert.SerializeObject(loanApplication);
                rejectedloanApplication = null;
            }
            else
            {
                rejectedloanApplication = JsonConvert.SerializeObject(loanApplication);
                approvedloanApplication = null;
            }
        }
    }
}
