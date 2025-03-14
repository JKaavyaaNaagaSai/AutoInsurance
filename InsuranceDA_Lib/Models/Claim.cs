using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDA_Lib.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int PolicyId { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string ClaimStatus { get; set; }
        public int AdjusterId { get; set; }

        public override string ToString()
        {
            return String.Format($"{ClaimId,12}{PolicyId,12}{ClaimAmount,15}{ClaimDate,20}{ClaimStatus,12}{AdjusterId,12}");
        }
    }

}
