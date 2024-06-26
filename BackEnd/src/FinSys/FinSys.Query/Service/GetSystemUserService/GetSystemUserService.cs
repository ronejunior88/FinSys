﻿using Dapper;
using FinSys.Query.Interfaces;
using FinSys.Query.Queries.GetSystemUserAll;
using FinSys.Query.Queries.GetSystemUserById;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FinSys.Query.Service.GetSystemUserService
{
    public class GetSystemUserService : IGetSystemUserService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public GetSystemUserService()
        {  }

        public GetSystemUserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<GetSystemUserAllResponse>> GetSystemUsersAllAsync()
        {
            _connection = _configuration.GetConnectionString("FinSys");

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"SELECT [Id], [Name], [DateBirth], [Email], [PasswordHash], [PasswordSalt] FROM SystemUser";

                var result = await connection.QueryAsync<GetSystemUserAllResponse>(sqlQuery);

                connection.Close();

                return result;
            }
        }

        public async Task<GetSystemUserByIdResponse> GetSystemUsersByIdAsync(GetSystemUserById request)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"SELECT [Id], [Name], [DateBirth], [Email], [PasswordHash], [PasswordSalt] FROM SystemUser WHERE [Id] = @Id";

                var result = await connection.QueryFirstOrDefaultAsync<GetSystemUserByIdResponse>(sqlQuery,request);

                connection.Close();
                return result;
            }
        }
    }
}
