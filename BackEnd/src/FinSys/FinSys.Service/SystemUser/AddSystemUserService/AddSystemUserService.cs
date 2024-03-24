using Dapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FinSys.Service.SystemUser.AddSystemUserService
{
    public class AddSystemUserService : IAddSystemUserService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public AddSystemUserService()
        { }

        public AddSystemUserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task AddSystemUser(SystemUserDTO systemUser)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"INSERT INTO SystemUser ([Id], [Name], [DateBirth]) VALUES (@Id, @Name, @DateBirth)";

                await connection.ExecuteAsync(sqlQuery, systemUser);

                connection.Close();
            }
        }
    }
}
