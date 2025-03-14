using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Repositories;
using InsuranceDA_Lib.Models;

namespace InsuranceBO_lib.Controllers
{
    public class PolicyBO
    {
        static PolicyRepository porepo = new PolicyRepository();

        public static void RemovePolicy(int policyId)
        {
            var pol = porepo.GetPolicyById(policyId);
            if (pol == null)
            {
                Console.WriteLine($"{policyId} is invalid");
            }
            else
            {
                if (porepo.DeletePolicy(pol))
                {
                    Console.WriteLine($"Policy with ID {policyId} is deleted");
                }
                else
                {
                    Console.WriteLine("Deletion FAILED");
                }
            }
        }

        public static void CreatePolicy(InsuranceBO_Lib.Models.Policy policy)
        {
            InsuranceDA_Lib.Models.Policy p = new InsuranceDA_Lib.Models.Policy()
            {
                PolicyNumber = policy.PolicyNumber,
                VehicleDetails = policy.VehicleDetails,
                CoverageAmount = policy.CoverageAmount,
                CoverageType = policy.CoverageType,
                PremiumAmount = policy.PremiumAmount,
                StartDate = policy.StartDate,
                EndDate = policy.EndDate,
                PolicyStatus = policy.PolicyStatus
            };

            if (porepo.CreatePolicy(p))
            {
                Console.WriteLine("Policy Details are Added!");
            }
            else
            {
                Console.WriteLine("Policy Details could not be Added!");
            }
        }

        public static void ViewPolicies()
        {
            var policies = porepo.GetAllPolicies();
            Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}{5,20}{6,20}{7,20}", "PolicyId", "PolicyNumber", "VehicleDetails", "CoverageAmount", "CoverageType", "PremiumAmount", "StartDate", "EndDate", "PolicyStatus");
            foreach (var policy in policies)
            {
                Console.WriteLine($"{policy.PolicyId,10}{policy.PolicyNumber,20}{policy.VehicleDetails,20}{policy.CoverageAmount,20}{policy.CoverageType,20}{policy.PremiumAmount,20}{policy.StartDate,20}{policy.EndDate,20}{policy.PolicyStatus,20}");
            }
        }

        public static void UpdatePolicy(int policyId)
        {
            var po = porepo.GetPolicyById(policyId);
            if (po == null)
            {
                Console.WriteLine($"{policyId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter PolicyNumber, VehicleDetails, CoverageAmount, CoverageType, PremiumAmount, StartDate, EndDate, PolicyStatus:");
                InsuranceDA_Lib.Models.Policy p = new InsuranceDA_Lib.Models.Policy()
                {
                    PolicyId = po.PolicyId,
                    PolicyNumber = Console.ReadLine(),
                    VehicleDetails = Console.ReadLine(),
                    CoverageAmount = Convert.ToDecimal(Console.ReadLine()),
                    CoverageType = Console.ReadLine(),
                    PremiumAmount = Convert.ToDecimal(Console.ReadLine()),
                    StartDate = Convert.ToDateTime(Console.ReadLine()),
                    EndDate = Convert.ToDateTime(Console.ReadLine()),
                    PolicyStatus = Console.ReadLine()
                };
                if (porepo.UpdatePolicy(p))
                {
                    Console.WriteLine("Policy Details are Modified!");
                }
                else
                {
                    Console.WriteLine("Policy Details could not be Modified!");
                }
            }
        }
    }
}