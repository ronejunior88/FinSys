using FinSys.Service.Domain;
using MediatR;

namespace FinSys.Service.Interfaces
{
    public interface IAddExpendingService
    {
        Task AddExpending(ExpendingDTO expending);
    }
}