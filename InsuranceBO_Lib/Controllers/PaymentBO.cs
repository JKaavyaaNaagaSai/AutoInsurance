using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;
using InsuranceDA_Lib.Repositories;

namespace InsuranceBO_lib
{
    public class PaymentBO
    {
        static PaymentRepository prepo = new PaymentRepository();

        public static void MakePayment(InsuranceBO_Lib.Models.Payment payment)
        {
            InsuranceDA_Lib.Models.Payment p = new InsuranceDA_Lib.Models.Payment()
            {
                PaymentId = payment.PaymentId,
                PaymentAmount = payment.PaymentAmount,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus,
                PolicyId = payment.PolicyId
            };

            if (prepo.MakePayment(p))
            {
                Console.WriteLine("Payment Details are Submitted!");
            }
            else
            {
                Console.WriteLine("Payment Details could not be submitted!");
            }
        }

        public static void GetPaymentDetails(int paymentId)
        {
            var payment = prepo.GetPaymentDetails(paymentId);
            if (payment != null)
            {
                Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}", "PaymentId", "PaymentAmount", "PaymentDate", "PaymentStatus", "PolicyId");
                Console.WriteLine($"{payment.PaymentId,15}{payment.PaymentAmount,15}{payment.PaymentDate,15}{payment.PaymentStatus,15}{payment.PolicyId,15}");
            }
            else
            {
                Console.WriteLine($"Payment with ID {paymentId} not found.");
            }
        }

        public static void GetPaymentsByPolicy(int policyId)
        {
            var payments = prepo.GetPaymentsByPolicy(policyId);
            if (payments != null && payments.Count > 0)
            {
                Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}", "PaymentId", "PaymentAmount", "PaymentDate", "PaymentStatus", "PolicyId");
                foreach (var payment in payments)
                {
                    Console.WriteLine($"{payment.PaymentId,15}{payment.PaymentAmount,15}{payment.PaymentDate,15}{payment.PaymentStatus,15}{payment.PolicyId,15}");
                }
            }
            else
            {
                Console.WriteLine($"No payments found for Policy ID {policyId}.");
            }
        }
    }
}