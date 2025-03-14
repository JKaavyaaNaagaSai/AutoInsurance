using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDA_Lib.Models
{
    public class SupportTicket
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string IssueDescription { get; set; }
        public string TicketStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }

        public override string ToString()
        {
            return String.Format($"{TicketId,12}{UserId,12}{IssueDescription,50}{TicketStatus,10}{CreatedDate,20}{ResolvedDate,20}");
        }
    }

}
