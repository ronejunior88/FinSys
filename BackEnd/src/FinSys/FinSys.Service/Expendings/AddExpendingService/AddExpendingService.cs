using AutoMapper;
using Dapper;
using DapperExtensions;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
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
                var command = $"INSERT INTO Expending ([Id], [Value], [Description]) VALUES ('{expending.Id}', '{expending.Value}', '{expending.Description}')";
                await connection.ExecuteAsync(command);
            }            
        }
    }
}