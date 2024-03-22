using Dapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;
using static Slapper.AutoMapper;

namespace FinSys.Service.Expendings.UploadExpendingService
{
    public class UploadExpendingService : IUploadExpendingService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public UploadExpendingService()
        { }

        public UploadExpendingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task AddUploadExpending(IEnumerable<ExpendingDTO> expendings)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"INSERT INTO Expending ([Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment], [IdUser]) VALUES (@Id, @Value, @Description, @Inative, @DateExpiration, @DateRelease, @DatePayment, @IdUser)";

                await connection.ExecuteAsync(sqlQuery, expendings);
                connection.Close();
            }          
        }
    }
}


