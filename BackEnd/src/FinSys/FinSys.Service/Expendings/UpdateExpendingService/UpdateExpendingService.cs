using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FinSys.Service.Expendings.UpdateExpendingService
{
    public class UpdateExpendingService : IUpdateExpendingService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public UpdateExpendingService()
        { }

        public UpdateExpendingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ExpendingDTO> UpdateExpending(ExpendingDTO expending)
        {
            _connection = _configuration.GetConnectionString("FinSys");
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "UPDATE Expending SET [Value] = @Value, [Description] = @Description, [Inative]= @Inative, [DateExpiration]= @DateExpiration, [DateRelease]= @DateRelease, [DatePayment]= @DatePayment WHERE [Id] = @Id";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
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
                    cmd.Parameters["@DatePayment"].Value = expending.DatePayment == null ? DBNull.Value : expending.DatePayment; ;

                    rowsAffected = cmd.ExecuteNonQueryAsync().Result;
                }

                connection.Close();
            }

            if (rowsAffected >= 1)
                return expending;

            return null;
        }
    }
}
