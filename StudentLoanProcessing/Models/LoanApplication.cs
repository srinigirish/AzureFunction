using System;
using System.Collections.Generic;
using System.Text;

namespace StudentLoanProcessing.Models
{
    public class LoanApplication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Address ContactInfo { get; set; }
        public float YearlyIncome { get; set; }
        public float LoanAmount { get; set; }

    }
}
