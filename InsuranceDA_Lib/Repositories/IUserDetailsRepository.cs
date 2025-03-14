using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public interface IUserDetailsRepository<T>
    {
        bool RegisterUser(T entity);
        T Login(string username, string password);
        bool Logout(int userId);
        T GetUserProfile(object id);
    }
}
