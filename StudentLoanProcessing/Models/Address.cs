using System;
using System.Collections.Generic;
using System.Text;

namespace StudentLoanProcessing.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public int Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
