using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public class SupportTicketRepository : ISupportTicketRepository<SupportTicket>
    {
        SqlConnection con;
        public SupportTicketRepository()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN512464; Initial Catalog=AutoDb; Integrated Security=True";
            }
        }

        public bool CreateTicket(SupportTicket entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO SUPPORT_TICKET VALUES(@p1,@p2,@p3,@p4,@p5,@p6)", con);
                cmd.Parameters.AddWithValue("@p1", entity.TicketId);
                cmd.Parameters.AddWithValue("@p2", entity.UserId);
                cmd.Parameters.AddWithValue("@p3", entity.IssueDescription);
                cmd.Parameters.AddWithValue("@p4", entity.TicketStatus);
                cmd.Parameters.AddWithValue("@p5", entity.CreatedDate);
                cmd.Parameters.AddWithValue("@p6", entity.ResolvedDate);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }

        public SupportTicket GetTicketDetails(object id)
        {
            int ticketId = (int)id; // unboxing
            List<SupportTicket> tickets = GetAllTickets();
            SupportTicket ticket = tickets.FirstOrDefault(t => t.TicketId == ticketId); // LINQ Syntax
            return ticket;
        }

        public bool ResolveTicket(SupportTicket entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE SUPPORT_TICKET SET UserId=@p2, IssueDescription=@p3, TicketStatus=@p4, CreatedDate=@p5, ResolvedDate=@p6 WHERE TicketId=@p1", con);
                cmd.Parameters.AddWithValue("@p2", entity.UserId);
                cmd.Parameters.AddWithValue("@p3", entity.IssueDescription);
                cmd.Parameters.AddWithValue("@p4", entity.TicketStatus);
                cmd.Parameters.AddWithValue("@p5", entity.CreatedDate);
                cmd.Parameters.AddWithValue("@p6", entity.ResolvedDate);
                cmd.Parameters.AddWithValue("@p1", entity.TicketId);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }

        public List<SupportTicket> GetAllTickets()
        {
            List<SupportTicket> tickets = new List<SupportTicket>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SUPPORT_TICKET", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                SupportTicket t = new SupportTicket()
                {
                    TicketId = Convert.ToInt32(sqldr[0].ToString()),
                    UserId = Convert.ToInt32(sqldr[1].ToString()),
                    IssueDescription = sqldr[2].ToString(),
                    TicketStatus = sqldr[3].ToString(),
                    CreatedDate = Convert.ToDateTime(sqldr[4]),
                    ResolvedDate = sqldr[5] != DBNull.Value ? Convert.ToDateTime(sqldr[5]) : (DateTime?)null
                };
                tickets.Add(t);
            }
            sqldr.Close();
            return tickets;
        }
    }
}