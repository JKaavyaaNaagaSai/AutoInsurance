using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public interface IPaymentRepository<T>
    {
        bool MakePayment(T entity);
        T GetPaymentDetails(object id);
        List<T> GetPaymentsByPolicy(object policyId);
    }
}