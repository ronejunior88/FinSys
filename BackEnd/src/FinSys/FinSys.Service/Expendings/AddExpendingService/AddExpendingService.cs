using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Service.Expendings.AddExpendingService
{
    public class AddExpendingService : IAddExpendingService
    {
        private readonly IConfiguration _configuration;
        public AddExpendingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<Unit> AddExpending(ExpendingDTO expending)
        {

        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ProdutoConnection").Value;
            return connection;
        }
    }
}