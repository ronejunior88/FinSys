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

                string sqlQuery = "INSERT INTO Expending ([Id], [Value], [Description]) VALUES (@Id, @Value, @Description)";

                using (SqlCommand cmd = new SqlCommand(sqlQuery,connection))
                {
                    cmd.Parameters.Add("@Id",SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@Id"].Value = expending.Id;

                    cmd.Parameters.Add("@Value", SqlDbType.Real);
                    cmd.Parameters["@Value"].Value = expending.Value;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Description"].Value = expending.Description;

                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                connection.Close();
            }            
        }
    }
}