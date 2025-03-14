using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InsuranceDA_Lib.Models;

namespace InsuranceDA_Lib.Repositories
{
    public class PolicyRepository : IPolicyRepository<Policy>
    {
        SqlConnection con;

        public PolicyRepository()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public string ConnectionString => "Data Source=LTIN512464; Initial Catalog=AutoDb; Integrated Security=True";

        public bool CreatePolicy(Policy entity)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = GenerateInsertCommand(entity);
                int rows = cmd.ExecuteNonQuery();
                result = rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Operation Failed - " + ex.Message);
            }
            return result;
        }

        public Policy GetPolicyById(object id)
        {
            SqlCommand cmd = GenerateSelectCommand(id);
            SqlDataReader reader = cmd.ExecuteReader();
            Policy entity = null;
            if (reader.Read())
            {
                entity = MapReaderToEntity(reader);
            }
            reader.Close();
            return entity;
        }

        public bool DeletePolicy(Policy entity)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = GenerateDeleteCommand(entity);
                int rows = cmd.ExecuteNonQuery();
                result = rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Operation Failed - " + ex.Message);
            }
            return result;
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> entities = new List<Policy>();
            SqlCommand cmd = GenerateSelectAllCommand();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Policy entity = MapReaderToEntity(reader);
                entities.Add(entity);
            }
            reader.Close();
            return entities;
        }

        public bool UpdatePolicy(Policy entity)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = GenerateUpdateCommand(entity);
                int rows = cmd.ExecuteNonQuery();
                result = rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Operation Failed - " + ex.Message);
            }
            return result;
        }

        private SqlCommand GenerateInsertCommand(Policy entity)
        {
            string query = "INSERT INTO Policy (PolicyNumber, VehicleDetails, CoverageAmount, CoverageType, PremiumAmount, StartDate, EndDate, PolicyStatus) " +
                           "VALUES (@PolicyNumber, @VehicleDetails, @CoverageAmount, @CoverageType, @PremiumAmount, @StartDate, @EndDate, @PolicyStatus)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PolicyNumber", entity.PolicyNumber);
            cmd.Parameters.AddWithValue("@VehicleDetails", entity.VehicleDetails);
            cmd.Parameters.AddWithValue("@CoverageAmount", entity.CoverageAmount);
            cmd.Parameters.AddWithValue("@CoverageType", entity.CoverageType);
            cmd.Parameters.AddWithValue("@PremiumAmount", entity.PremiumAmount);
            cmd.Parameters.AddWithValue("@StartDate", entity.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", entity.EndDate);
            cmd.Parameters.AddWithValue("@PolicyStatus", entity.PolicyStatus);
            return cmd;
        }

        private SqlCommand GenerateSelectCommand(object id)
        {
            string query = "SELECT * FROM Policy WHERE PolicyId = @PolicyId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PolicyId", id);
            return cmd;
        }

        private SqlCommand GenerateDeleteCommand(Policy entity)
        {
            string query = "DELETE FROM Policy WHERE PolicyId = @PolicyId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PolicyId", entity.PolicyId);
            return cmd;
        }

        private SqlCommand GenerateSelectAllCommand()
        {
            string query = "SELECT * FROM Policies";
            SqlCommand cmd = new SqlCommand(query, con);
            return cmd;
        }

        private SqlCommand GenerateUpdateCommand(Policy entity)
        {
            string query = "UPDATE Policies SET PolicyNumber = @PolicyNumber, VehicleDetails = @VehicleDetails, CoverageAmount = @CoverageAmount, " +
                           "CoverageType = @CoverageType, PremiumAmount = @PremiumAmount, StartDate = @StartDate, EndDate = @EndDate, PolicyStatus = @PolicyStatus " +
                           "WHERE PolicyId = @PolicyId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PolicyId", entity.PolicyId);
            cmd.Parameters.AddWithValue("@PolicyNumber", entity.PolicyNumber);
            cmd.Parameters.AddWithValue("@VehicleDetails", entity.VehicleDetails);
            cmd.Parameters.AddWithValue("@CoverageAmount", entity.CoverageAmount);
            cmd.Parameters.AddWithValue("@CoverageType", entity.CoverageType);
            cmd.Parameters.AddWithValue("@PremiumAmount", entity.PremiumAmount);
            cmd.Parameters.AddWithValue("@StartDate", entity.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", entity.EndDate);
            cmd.Parameters.AddWithValue("@PolicyStatus", entity.PolicyStatus);
            return cmd;
        }

        private Policy MapReaderToEntity(SqlDataReader reader)
        {
            return new Policy
            {
                PolicyId = Convert.ToInt32(reader["PolicyId"]),
                PolicyNumber = reader["PolicyNumber"].ToString(),
                VehicleDetails = reader["VehicleDetails"].ToString(),
                CoverageAmount = Convert.ToDecimal(reader["CoverageAmount"]),
                CoverageType = reader["CoverageType"].ToString(),
                PremiumAmount = Convert.ToDecimal(reader["PremiumAmount"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = Convert.ToDateTime(reader["EndDate"]),
                PolicyStatus = reader["PolicyStatus"].ToString()
            };
        }
    }
}

        