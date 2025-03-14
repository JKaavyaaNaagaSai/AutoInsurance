using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;
using InsuranceDA_Lib.Repositories;

namespace InsuranceBO_lib
{
    public class ClaimBO
    {
        static ClaimRepository crepo = new ClaimRepository();

        public static void SubmitClaim(InsuranceBO_Lib.Models.Claim claim)
        {
            InsuranceDA_Lib.Models.Claim cs = new InsuranceDA_Lib.Models.Claim()
            {
                ClaimId = claim.ClaimId,
                PolicyId = claim.PolicyId,
                ClaimAmount = claim.ClaimAmount,
                ClaimDate = claim.ClaimDate,
                ClaimStatus = claim.ClaimStatus,
                AdjusterId = claim.AdjusterId
            };

            if (crepo.SubmitClaim(cs))
            {
                Console.WriteLine("Claim Details are Submitted!");
            }
            else
            {
                Console.WriteLine("Claim Details could not be submitted!");
            }
        }

        public static void GetClaimDetails(int claimId)
        {
            var claim = crepo.GetClaimDetails(claimId);
            if (claim != null)
            {
                Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}", "ClaimId", "PolicyId", "ClaimAmount", "ClaimDate", "ClaimStatus", "AdjusterId");
                Console.WriteLine($"{claim.ClaimId,15}{claim.PolicyId,15}{claim.ClaimAmount,15}{claim.ClaimDate,15}{claim.ClaimStatus,15}{claim.AdjusterId,15}");
            }
            else
            {
                Console.WriteLine($"Claim with ID {claimId} not found.");
            }
        }

        public static void ProcessClaim(int claimId)
        {
            var claim = crepo.GetClaimDetails(claimId);
            if (claim == null)
            {
                Console.WriteLine($"{claimId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter PolicyId, ClaimAmount, ClaimDate (MM/dd/yyyy), ClaimStatus, AdjusterId:");
                InsuranceDA_Lib.Models.Claim c = new InsuranceDA_Lib.Models.Claim()
                {
                    ClaimId = claim.ClaimId,
                    PolicyId = Convert.ToInt32(Console.ReadLine()),
                    ClaimAmount = Convert.ToDecimal(Console.ReadLine()),
                    ClaimDate = ReadDate("ClaimDate"),
                    ClaimStatus = Console.ReadLine(),
                    AdjusterId = Convert.ToInt32(Console.ReadLine())
                };
                if (crepo.UpdateClaimStatus(c))
                {
                    Console.WriteLine("Claim Details are Processed!");
                }
                else
                {
                    Console.WriteLine("Claim Details could not be Processed!");
                }
            }
        }

        private static DateTime ReadDate(string fieldName)
        {
            DateTime date;
            Console.WriteLine($"Enter {fieldName} (MM/dd/yyyy):");
            while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                Console.WriteLine($"Invalid date format. Please enter the {fieldName} in MM/dd/yyyy format:");
            }
            return date;
        }
    }
}