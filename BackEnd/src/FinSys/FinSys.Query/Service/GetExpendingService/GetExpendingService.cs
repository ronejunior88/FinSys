using FinSys.Query.Domain;
using FinSys.Query.Interfaces;
using Microsoft.Extensions.Configuration;
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
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
            }
            return expendingList;
        }
    }
}
