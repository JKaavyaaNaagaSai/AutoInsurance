using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDA_Lib.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public string VehicleDetails { get; set; }
        public decimal CoverageAmount { get; set; }
        public string CoverageType { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PolicyStatus { get; set; }

        public override string ToString()
        {
            return String.Format($"{PolicyId,12}{PolicyNumber,20}{VehicleDetails,30}{CoverageAmount,15}{CoverageType,15}{PremiumAmount,15}{StartDate,20}{EndDate,20}{PolicyStatus,10}");
        }
    }

}
