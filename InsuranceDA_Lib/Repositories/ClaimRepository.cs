using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public class ClaimRepository : IClaimRepository<Claim>
    {
        SqlConnection con;
        public ClaimRepository()
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
        public bool SubmitClaim(Claim entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CLAIM VALUES(@p1,@p2,@p3,@p4,@p5,@p6)", con);
                cmd.Parameters.Add("@p1", entity.ClaimId);
                cmd.Parameters.Add("@p2", entity.PolicyId);
                cmd.Parameters.Add("@p3", entity.ClaimAmount);
                cmd.Parameters.Add("@p4", entity.ClaimDate);
                cmd.Parameters.Add("@p5", entity.ClaimStatus);
                cmd.Parameters.Add("@p6", entity.AdjusterId);
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

        public Claim GetClaimDetails(object id)
        {
            int claimId = (int)id;     // unboxing
            List<Claim> claims = GetAllClaims();
            Claim claim = claims.Where(c => c.ClaimId == claimId).FirstOrDefault();  // LINQ Syntax
            return claim;
        }
        public bool UpdateClaimStatus(Claim entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update CLAIM Set PolicyId=@p2, ClaimAmount=@p3, ClaimDate=@p4, ClaimStatus=@p5, AdjusterId=@p6 where ClaimId=@p1", con);

                cmd.Parameters.Add("@p2", entity.PolicyId);
                cmd.Parameters.Add("@p3", entity.ClaimAmount);
                cmd.Parameters.Add("@p4", entity.ClaimDate);
                cmd.Parameters.Add("@p5", entity.ClaimStatus);
                cmd.Parameters.Add("@p6", entity.AdjusterId);
                cmd.Parameters.Add("@p1", entity.ClaimId);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }
        public List<Claim> GetAllClaims()
        {
            List<Claim> claims = new List<Claim>();
            SqlCommand cmd = new SqlCommand("Select * from CLAIM", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Claim c = new Claim()
                {
                    ClaimId = Convert.ToInt32(sqldr[0].ToString()),
                    PolicyId = Convert.ToInt32(sqldr[1].ToString()),
                    ClaimAmount = Convert.ToDecimal(sqldr[2]),
                    ClaimDate = Convert.ToDateTime(sqldr[3]),
                    ClaimStatus = sqldr[4].ToString(),
                    AdjusterId = Convert.ToInt32(sqldr[5].ToString())
                };
                claims.Add(c);
            }
            sqldr.Close();
            return claims;
        }
    }
}
