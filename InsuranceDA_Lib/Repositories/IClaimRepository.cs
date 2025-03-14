using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public interface IClaimRepository<T>
    {
        bool SubmitClaim(T entity);
        T GetClaimDetails(object id);
        bool UpdateClaimStatus(T entity);
        List<T> GetAllClaims();
    }
}
