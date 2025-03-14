using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public class UserDetailsRepository : IUserDetailsRepository<UserDetails>
    {
        SqlConnection con;
        public UserDetailsRepository()
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

        public bool RegisterUser(UserDetails entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO USERS VALUES(@p1,@p2,@p3,@p4,@p5)", con);
                cmd.Parameters.AddWithValue("@p1", entity.UserId);
                cmd.Parameters.AddWithValue("@p2", entity.Username);
                cmd.Parameters.AddWithValue("@p3", entity.Password);
                cmd.Parameters.AddWithValue("@p4", entity.Email);
                cmd.Parameters.AddWithValue("@p5", entity.Role);
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

        public UserDetails Login(string username, string password)
        {
            UserDetails user = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE Username=@p1 AND Password=@p2", con);
                cmd.Parameters.AddWithValue("@p1", username);
                cmd.Parameters.AddWithValue("@p2", password);
                SqlDataReader sqldr = cmd.ExecuteReader();
                if (sqldr.Read())
                {
                    user = new UserDetails()
                    {
                        UserId = Convert.ToInt32(sqldr[0].ToString()),
                        Username = sqldr[1].ToString(),
                        Password = sqldr[2].ToString(),
                        Email = sqldr[3].ToString(),
                        Role = sqldr[4].ToString()
                    };
                }
                sqldr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login Operation Failed -" + ex.Message);
            }
            return user;
        }

        public bool Logout(int userId)
        {
            // Assuming logout is a simple operation that always succeeds
            Console.WriteLine("User with ID " + userId + " logged out.");
            return true;
        }

        public UserDetails GetUserProfile(object id)
        {
            int userId = (int)id; // unboxing
            UserDetails user = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE UserId=@p1", con);
                cmd.Parameters.AddWithValue("@p1", userId);
                SqlDataReader sqldr = cmd.ExecuteReader();
                if (sqldr.Read())
                {
                    user = new UserDetails()
                    {
                        UserId = Convert.ToInt32(sqldr[0].ToString()),
                        Username = sqldr[1].ToString(),
                        Password = sqldr[2].ToString(),
                        Email = sqldr[3].ToString(),
                        Role = sqldr[4].ToString()
                    };
                }
                sqldr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get User Profile Operation Failed -" + ex.Message);
            }
            return user;
        }
    }
}