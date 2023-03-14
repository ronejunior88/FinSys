using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;

namespace FinSys.Service.Expendings.AddExpendingService
{
    public class AddExpendingService : IAddExpendingService
    {
        public Task<Unit> AddExpending(ExpendingDTO expending)
        {
            throw new NotImplementedException();
        }
    }
}