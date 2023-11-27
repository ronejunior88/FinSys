﻿using FinSys.Query.Interfaces;
using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using Microsoft.Extensions.Configuration;
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

            var expendingList = new List<GetExpendingsAllResponse>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "SELECT [Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment] FROM Expending";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            GetExpendingsAllResponse expending = new GetExpendingsAllResponse
                            {
                                Id = (Guid)reader["Id"],
                                Value = (decimal)reader["Value"],
                                Description = (string)reader["Description"],
                                Inative = (bool)reader["Inative"],
                                DateExpiration = (DateTime)reader["DateExpiration"],
                                DateRelease = (DateTime)reader["DateRelease"],
                                DatePayment = reader["DatePayment"] == DBNull.Value ? null : (DateTime)reader["DatePayment"]
                            };
                            expendingList.Add(expending);
                        }
                    }
                }
                connection.Close();
            }
            return expendingList;
        }

        public async Task<GetExpendingsByIdResponse> GetExpendingByIdAsync(GetExpendingsById _request)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            GetExpendingsByIdResponse expending = new GetExpendingsByIdResponse();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "SELECT [Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment] FROM Expending WHERE [id] = @Id";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@Id"].Value = _request.Id;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            expending.Id = (Guid)reader["Id"];
                            expending.Value = (decimal)reader["Value"];
                            expending.Description = (string)reader["Description"];
                            expending.Inative = (bool)reader["Inative"];
                            expending.DateExpiration = (DateTime)reader["DateExpiration"];
                            expending.DateRelease = (DateTime)reader["DateRelease"];
                            expending.DatePayment = reader["DatePayment"] == DBNull.Value ? null : (DateTime)reader["DatePayment"];
                        }
                    }
                }
                connection.Close();
            }
            return expending;
        }

        public async Task<IEnumerable<GetExpendingByValueResponse>> GetExpendingByValueAsync(GetExpendingByValue _request)
        {
            _connection = _configuration.GetConnectionString("FinSys");

            var expendingList = new List<GetExpendingByValueResponse>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "SELECT [Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment] FROM Expending WHERE [Value] = @Value";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@Value", SqlDbType.Float);
                    cmd.Parameters["@Value"].Value = _request.Value;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            GetExpendingByValueResponse expending = new GetExpendingByValueResponse
                            {
                                Id = (Guid)reader["Id"],
                                Value = (decimal)reader["Value"],
                                Description = (string)reader["Description"],
                                Inative = (bool)reader["Inative"],
                                DateExpiration = (DateTime)reader["DateExpiration"],
                                DateRelease = (DateTime)reader["DateRelease"],
                                DatePayment = reader["DatePayment"] == DBNull.Value ? null : (DateTime)reader["DatePayment"]
                            };
                            expendingList.Add(expending);
                        }
                    }
                }
                connection.Close();
            }
            return expendingList;
        }
    }
}
