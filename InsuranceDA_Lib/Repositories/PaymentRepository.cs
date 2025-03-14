using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public class PaymentRepository : IPaymentRepository<Payment>
    {
        SqlConnection con;
        public PaymentRepository()
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
        public bool MakePayment(Payment entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO PAYMENT VALUES(@p1,@p2,@p3,@p4,@p5)", con);
                cmd.Parameters.Add("@p1", entity.PaymentId);
                cmd.Parameters.Add("@p2", entity.PaymentAmount);
                cmd.Parameters.Add("@p3", entity.PaymentDate);
                cmd.Parameters.Add("@p4", entity.PaymentStatus);
                cmd.Parameters.Add("@p5", entity.PolicyId);
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

        public Payment GetPaymentDetails(object id)
        {
            int paymentId = (int)id;     // unboxing
            List<Payment> payments = GetAllPayments();
            Payment payment = payments.Where(p => p.PaymentId == paymentId).FirstOrDefault();  // LINQ Syntax
            return payment;
        }

        public List<Payment> GetPaymentsByPolicy(object policyId)
        {
            int policyIdInt = (int)policyId;     // unboxing
            List<Payment> payments = GetAllPayments();
            List<Payment> policyPayments = payments.Where(p => p.PolicyId == policyIdInt).ToList();  // LINQ Syntax
            return policyPayments;
        }

        private List<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();
            SqlCommand cmd = new SqlCommand("Select * from PAYMENT", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Payment p = new Payment()
                {
                    PaymentId = Convert.ToInt32(sqldr[0].ToString()),
                    PaymentAmount = Convert.ToDecimal(sqldr[1]),
                    PaymentDate = Convert.ToDateTime(sqldr[2]),
                    PaymentStatus = sqldr[3].ToString(),
                    PolicyId = Convert.ToInt32(sqldr[4].ToString())
                };
                payments.Add(p);
            }
            sqldr.Close();
            return payments;
        }
    }
}