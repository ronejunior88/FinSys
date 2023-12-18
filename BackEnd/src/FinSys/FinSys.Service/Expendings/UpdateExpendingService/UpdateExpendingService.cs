using Dapper;
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

                string sqlQuery = @"UPDATE Expending SET [Value] = @Value, [Description] = @Description, [Inative]= @Inative, [DateExpiration]= @DateExpiration, [DateRelease]= @DateRelease, [DatePayment]= @DatePayment WHERE [Id] = @Id";

                rowsAffected = connection.ExecuteAsync(sqlQuery, expending).Result;
                connection.Close();
            }

            if (rowsAffected >= 1)
                return expending;

            return null;
        }
    }
}
