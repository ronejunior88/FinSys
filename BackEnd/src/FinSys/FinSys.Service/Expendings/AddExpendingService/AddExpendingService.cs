using Dapper;
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

                string sqlQuery = @"INSERT INTO Expending ([Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment], [IdUser]) VALUES (@Id, @Value, @Description, @Inative, @DateExpiration, @DateRelease, @DatePayment, @IdUser)";

                await connection.ExecuteAsync(sqlQuery, expending);
                
                connection.Close();
            }            
        }
    }
}