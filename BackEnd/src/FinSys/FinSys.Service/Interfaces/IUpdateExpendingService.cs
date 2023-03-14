using FinSys.Service.Domain;

namespace FinSys.Service.Interfaces
{
    public interface IUpdateExpendingService
    {
        Task<ExpendingDTO> AddExpending(ExpendingDTO expending);
    }
}