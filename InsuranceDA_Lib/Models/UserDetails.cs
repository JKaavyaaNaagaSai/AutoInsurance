using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDA_Lib.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return String.Format($"{UserId,12}{Username,20}{Password,30}{Email,30}{Role,10}");
        }
    }

}
