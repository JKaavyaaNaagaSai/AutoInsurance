using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBO_Lib.Models
{
    public class SupportTicket
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string IssueDescription { get; set; }
        public string TicketStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
    }
}
