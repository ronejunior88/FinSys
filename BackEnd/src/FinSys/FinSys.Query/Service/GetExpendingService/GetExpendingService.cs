using FinSys.Query.Domain;
using FinSys.Query.Interfaces;
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

        public async Task<IEnumerable<Expending>> GetExpendingAsync()
        {
            _connection = _configuration.GetConnectionString("FinSys");

            var expendingList = new List<Expending>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "SELECT [Id], [Value], [Description] FROM Expending";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Expending expending = new Expending
                            {
                                Id = (Guid)reader["Id"],
                                Value = (double)reader["Value"],
                                Description = (string)reader["Description"]
                            };
                            expendingList.Add(expending);
                        }
                    }
                }
                connection.Close();
            }
            return expendingList;
        }

        public async Task<Expending> GetExpendingByIdAsync(Guid id)
        {
            _connection = _configuration.GetConnectionString("FinSys");
            Expending expending = new Expending();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "SELECT [Id], [Value], [Description] FROM Expending WHERE [id] = @Id";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@Id"].Value = id;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            expending.Id = (Guid)reader["Id"];
                            expending.Value = (double)reader["Value"];
                            expending.Description = (string)reader["Description"];
                        }
                    }
                }
                connection.Close();
            }
            return expending;
        }
    }
}
