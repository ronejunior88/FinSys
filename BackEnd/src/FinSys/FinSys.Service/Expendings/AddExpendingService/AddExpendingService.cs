using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FinSys.Service.Expendings.AddExpendingService
{
    public class AddExpendingService : IAddExpendingService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public AddExpendingService()
        {  }

        public AddExpendingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task AddExpending(ExpendingDTO expending)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Expending ([Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment]) VALUES (@Id, @Value, @Description, @Inative, @DateExpiration, @DateRelease, @DatePayment)";

                using (SqlCommand cmd = new SqlCommand(sqlQuery,connection))
                {
                    cmd.Parameters.Add("@Id",SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@Id"].Value = expending.Id;

                    cmd.Parameters.Add("@Value", SqlDbType.Decimal);
                    cmd.Parameters["@Value"].Value = expending.Value;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Description"].Value = expending.Description;

                    cmd.Parameters.Add("@Inative", SqlDbType.Bit, 100);
                    cmd.Parameters["@Inative"].Value = expending.Inative;

                    cmd.Parameters.Add("@DateExpiration", SqlDbType.DateTime);
                    cmd.Parameters["@DateExpiration"].Value = expending.DateExpiration;

                    cmd.Parameters.Add("@DateRelease", SqlDbType.DateTime);
                    cmd.Parameters["@DateRelease"].Value = expending.DateRelease;

                    
                    cmd.Parameters.Add("@DatePayment", SqlDbType.DateTime);
                    cmd.Parameters["@DatePayment"].Value = expending.DatePayment == null ? DBNull.Value : expending.DatePayment;

                    int rowsAffected = cmd.ExecuteNonQueryAsync().Result;
                }

                connection.Close();
            }            
        }
    }
}