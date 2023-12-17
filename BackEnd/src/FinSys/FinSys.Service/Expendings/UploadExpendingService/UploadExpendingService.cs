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

                string sqlQuery = "INSERT INTO Expending ([Id], [Value], [Description], [Inative], [DateExpiration], [DateRelease], [DatePayment]) VALUES (@Id, @Value, @Description, @Inative, @DateExpiration, @DateRelease, @DatePayment)";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    foreach (var item in expendings)
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                        cmd.Parameters["@Id"].Value = item.Id;

                        cmd.Parameters.Add("@Value", SqlDbType.Decimal);
                        cmd.Parameters["@Value"].Value = item.Value;

                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 100);
                        cmd.Parameters["@Description"].Value = item.Description;

                        cmd.Parameters.Add("@Inative", SqlDbType.Bit, 100);
                        cmd.Parameters["@Inative"].Value = item.Inative;

                        cmd.Parameters.Add("@DateExpiration", SqlDbType.DateTime);
                        cmd.Parameters["@DateExpiration"].Value = item.DateExpiration;

                        cmd.Parameters.Add("@DateRelease", SqlDbType.DateTime);
                        cmd.Parameters["@DateRelease"].Value = item.DateRelease;


                        cmd.Parameters.Add("@DatePayment", SqlDbType.DateTime);
                        cmd.Parameters["@DatePayment"].Value = item.DatePayment == null ? DBNull.Value : item.DatePayment;
                    }
                    connection.BulkInsert(sqlQuery, cmd.Parameters);
                }         
                connection.Close();
            }
        }
    }
}

