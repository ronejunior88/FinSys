using FinSys.Service.Domain;
using MediatR;

namespace FinSys.Service.Interfaces
{
    public interface IAddExpendingService
    {
        Task<Unit> AddExpending(ExpendingDTO expending);
    }
}