using Dapper;
using DapperExtensions;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FinSys.Service.Expendings.AddExpendingService
{
    public class AddExpendingService : IAddExpendingService
    {
        //private readonly IConfiguration _configuration;
        //private IDbConnection _connection = _configuration.GetSection("ConnectionStrings").GetSection("ProdutoConnection").Value;
        public AddExpendingService(IConfiguration configuration)
        {
            //_configuration = configuration;
            //_connection = _configuration.GetSection("ConnectionStrings").GetSection("ProdutoConnection").Value;
        }
        public Task<Unit> AddExpending(ExpendingDTO expending)
        {
            //_connection.ExecuteAsync("@INSERT INTO Expending VALUES()");
            return null;
        }
    }
}