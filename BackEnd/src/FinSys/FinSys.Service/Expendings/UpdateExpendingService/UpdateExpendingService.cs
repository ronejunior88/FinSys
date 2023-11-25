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

namespace FinSys.Service.Expendings.UpdateExpendingService
{
    public class UpdateExpendingService : IUpdateExpendingService
    {
        private readonly IConfiguration _configuration;
        private string _connection;

        public UpdateExpendingService()
        { }

        public UpdateExpendingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ExpendingDTO> UpdateExpending(ExpendingDTO expending)
        {
            _connection = _configuration.GetConnectionString("FinSys");
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string sqlQuery = "UPDATE Expending SET [Value] = @Value, [Description] = @Description, [Inative]= @Inative WHERE [Id] = @Id";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@Id"].Value = expending.Id;

                    cmd.Parameters.Add("@Value", SqlDbType.Real);
                    cmd.Parameters["@Value"].Value = expending.Value;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Description"].Value = expending.Description;

                    cmd.Parameters.Add("@Inative", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Inative"].Value = expending.Inative;

                    rowsAffected = cmd.ExecuteNonQueryAsync().Result;

                }

                connection.Close();
            }

            if (rowsAffected >= 1)
                return expending;

            return null;
        }
    }
}
