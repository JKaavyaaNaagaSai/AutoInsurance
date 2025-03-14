using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Repositories;
using InsuranceDA_Lib.Models;

namespace InsuranceBO_lib.Controllers
{
    public class UserDetailsBO
    {
        static UserDetailsRepository userRepo = new UserDetailsRepository();

        public static void RegisterUser(InsuranceBO_Lib.Models.UserDetails user)
        {
            InsuranceDA_Lib.Models.UserDetails u = new InsuranceDA_Lib.Models.UserDetails()
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Role = user.Role
            };

            if (userRepo.RegisterUser(u))
            {
                Console.WriteLine("User Registered Successfully!");
            }
            else
            {
                Console.WriteLine("User Registration Failed!");
            }
        }

        public static void Login(string username, string password)
        {
            var user = userRepo.Login(username, password);
            if (user == null)
            {
                Console.WriteLine("Invalid Username or Password");
            }
            else
            {
                Console.WriteLine($"Welcome {user.Username}!");
            }
        }

        public static void Logout(int userId)
        {
            if (userRepo.Logout(userId))
            {
                Console.WriteLine($"User with ID {userId} logged out successfully.");
            }
            else
            {
                Console.WriteLine("Logout Failed!");
            }
        }

        public static void ViewUserProfile(int userId)
        {
            var user = userRepo.GetUserProfile(userId);
            if (user == null)
            {
                Console.WriteLine($"{userId} is invalid");
            }
            else
            {
                Console.WriteLine("User Profile:");
                Console.WriteLine($"UserId: {user.UserId}");
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Role: {user.Role}");
            }
        }

        public static void UpdateUserProfile(int userId)
        {
            var u = userRepo.GetUserProfile(userId);
            if (u == null)
            {
                Console.WriteLine($"{userId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter Username, Password, Email, Role:");
                InsuranceDA_Lib.Models.UserDetails user = new InsuranceDA_Lib.Models.UserDetails()
                {
                    UserId = u.UserId,
                    Username = Console.ReadLine(),
                    Password = Console.ReadLine(),
                    Email = Console.ReadLine(),
                    Role = Console.ReadLine()
                };
                if (userRepo.RegisterUser(user))
                {
                    Console.WriteLine("User Profile Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("User Profile Update Failed!");
                }
            }
        }
    }
}
