using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Repositories;
using InsuranceDA_Lib.Models;

namespace InsuranceBO_lib.Controllers
{
    public class SupportTicketBO
    {
        static SupportTicketRepository ticketRepo = new SupportTicketRepository();

        public static void RemoveTicket(int ticketId)
        {
            var ticket = ticketRepo.GetTicketDetails(ticketId);
            if (ticket == null)
            {
                Console.WriteLine($"{ticketId} is invalid");
            }
            else
            {
                if (ticketRepo.ResolveTicket(ticket))
                {
                    Console.WriteLine($"Ticket with ID {ticketId} is deleted");
                }
                else
                {
                    Console.WriteLine("Deletion FAILED");
                }
            }
        }

        public static void CreateTicket(InsuranceBO_Lib.Models.SupportTicket ticket)
        {
            InsuranceDA_Lib.Models.SupportTicket t = new InsuranceDA_Lib.Models.SupportTicket()
            {
                TicketId = ticket.TicketId,
                UserId = ticket.UserId,
                IssueDescription = ticket.IssueDescription,
                TicketStatus = ticket.TicketStatus,
                CreatedDate = ticket.CreatedDate,
                ResolvedDate = ticket.ResolvedDate
            };

            if (ticketRepo.CreateTicket(t))
            {
                Console.WriteLine("Ticket Details are Added!");
            }
            else
            {
                Console.WriteLine("Ticket Details could not be Added!");
            }
        }

        public static void ViewTickets()
        {
            var tickets = ticketRepo.GetAllTickets();
            Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}{5,20}{6,20}", "TicketId", "UserId", "IssueDescription", "TicketStatus", "CreatedDate", "ResolvedDate");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"{ticket.TicketId,10}{ticket.UserId,20}{ticket.IssueDescription,20}{ticket.TicketStatus,20}{ticket.CreatedDate,20}{ticket.ResolvedDate,20}");
            }
        }

        public static void UpdateTicket(int ticketId)
        {
            var t = ticketRepo.GetTicketDetails(ticketId);
            if (t == null)
            {
                Console.WriteLine($"{ticketId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter UserId, IssueDescription, TicketStatus, CreatedDate, ResolvedDate:");
                InsuranceDA_Lib.Models.SupportTicket ticket = new InsuranceDA_Lib.Models.SupportTicket()
                {
                    TicketId = t.TicketId,
                    UserId = Convert.ToInt32(Console.ReadLine()),
                    IssueDescription = Console.ReadLine(),
                    TicketStatus = Console.ReadLine(),
                    CreatedDate = Convert.ToDateTime(Console.ReadLine()),
                    ResolvedDate = Convert.ToDateTime(Console.ReadLine())
                };
                if (ticketRepo.ResolveTicket(ticket))
                {
                    Console.WriteLine("Ticket Details are Modified!");
                }
                else
                {
                    Console.WriteLine("Ticket Details could not be Modified!");
                }
            }
        }
    }
}
