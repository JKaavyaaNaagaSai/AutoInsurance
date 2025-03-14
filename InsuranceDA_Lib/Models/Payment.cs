using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDA_Lib.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int PolicyId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }

        public override string ToString()
        {
            return String.Format($"{PaymentId,12}{PolicyId,12}{PaymentAmount,15}{PaymentDate,20}{PaymentStatus,12}");
        }
    }

}
