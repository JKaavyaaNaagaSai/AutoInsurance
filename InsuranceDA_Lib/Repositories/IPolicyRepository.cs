using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public interface IPolicyRepository<T>
    {
        bool CreatePolicy(T entity);
        bool UpdatePolicy(T entity);
        T GetPolicyById(object id);
        List<T> GetAllPolicies();
        bool DeletePolicy(T entity);
    }
}
