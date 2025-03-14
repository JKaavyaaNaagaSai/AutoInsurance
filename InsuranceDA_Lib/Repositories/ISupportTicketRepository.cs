using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public interface ISupportTicketRepository<T>
    {
        bool CreateTicket(T entity);
        T GetTicketDetails(object id);
        bool ResolveTicket(T entity);
        List<T> GetAllTickets();
    }
}
