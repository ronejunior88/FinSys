using Dapper;
using FinSys.Query.Interfaces;
using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FinSys.Query.Service.GetExpendingService
{
    public class GetExpendingService : IGetExpendingService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public GetExpendingService()
        { }

        public GetExpendingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<GetExpendingsAllResponse>> GetExpendingsAllAsync()
        {
            _connection = _configuration.GetConnectionString("FinSys");
            IEnumerable<GetExpendingsAllResponse> result;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"SELECT [Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment], [IdUser] FROM Expending";

                result = await connection.QueryAsync<GetExpendingsAllResponse>(sqlQuery);

                connection.Close();
            }
            return result;
        }

        public async Task<GetExpendingsByIdResponse> GetExpendingByIdAsync(GetExpendingsById request)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            GetExpendingsByIdResponse result;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"SELECT [Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment], [IdUser] FROM Expending WHERE [id] = @Id";

                result = await connection.QueryFirstOrDefaultAsync<GetExpendingsByIdResponse>(sqlQuery,request);

                connection.Close();
            }
            return result;
        }


        public async Task<IEnumerable<GetExpendingByValueResponse>> GetExpendingByValueAsync(GetExpendingByValue request)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            IEnumerable<GetExpendingByValueResponse> expendingList;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = @"SELECT [Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment], [IdUser] FROM Expending WHERE [Value] = @Value";

                expendingList = await connection.QueryAsync<GetExpendingByValueResponse>(sqlQuery, request);

                connection.Close();
            }
            return expendingList;
        }
    }
}
