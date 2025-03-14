using InsuranceBO_lib.Controllers;
using System;

namespace InsuranceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Update Policy");
                Console.WriteLine("4. Remove Policy");
                Console.WriteLine("5. Exit");

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Wish to create a new policy? Press Y");
                        string ans = Console.ReadLine();
                        while (ans.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter PolicyNumber, VehicleDetails, CoverageAmount, CoverageType, PremiumAmount, StartDate, EndDate, PolicyStatus");
                            InsuranceBO_Lib.Models.Policy policy = new InsuranceBO_Lib.Models.Policy()
                            {
                                PolicyNumber = Console.ReadLine(),
                                VehicleDetails = Console.ReadLine(),
                                CoverageAmount = Convert.ToDecimal(Console.ReadLine()),
                                CoverageType = Console.ReadLine(),
                                PremiumAmount = Convert.ToDecimal(Console.ReadLine()),
                                StartDate = Convert.ToDateTime(Console.ReadLine()),
                                EndDate = Convert.ToDateTime(Console.ReadLine()),
                                PolicyStatus = Console.ReadLine()
                            };
                            PolicyBO.CreatePolicy(policy);
                            Console.WriteLine("Wish to create more policies? Press Y");
                            ans = Console.ReadLine();
                        }
                        break;
                    case 2:
                        PolicyBO.ViewPolicies();
                        break;
                    case 3:
                        Console.WriteLine("Enter valid Policy Id for update");
                        int policyId = Convert.ToInt32(Console.ReadLine());
                        PolicyBO.UpdatePolicy(policyId);
                        break;
                    case 4:
                        Console.WriteLine("Enter valid Policy Id to remove");
                        int policyIdToRemove = Convert.ToInt32(Console.ReadLine());
                        PolicyBO.RemovePolicy(policyIdToRemove);
                        break;
                    case 5:
                        Console.WriteLine("Terminating...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter the correct option");
                        break;
                }
            }
        }
    }
}