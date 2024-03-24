using Dapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FinSys.Service.SystemUser.UpdateSystemUserService
{
    public class UpdateSystemUseService : IUpdateSystemUseService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public UpdateSystemUseService()
        {  }

        public UpdateSystemUseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SystemUserDTO> UpdateSystemUser(SystemUserDTO systemUser)
        {
            _connection = _configuration.GetConnectionString("FinSys");
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"UPDATE SystemUser SET [Name] = @Name, [DateBirth] = @DateBirth WHERE [Id] = @Id";

                rowsAffected = connection.ExecuteAsync(sqlQuery, systemUser).Result;
                connection.Close();
            }

            if (rowsAffected >= 1)
                return systemUser;

            return null;
        }
    }
}
