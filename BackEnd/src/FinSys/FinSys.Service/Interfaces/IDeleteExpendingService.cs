using FinSys.Service.Domain;

namespace FinSys.Service.Interfaces
{
    public interface IDeleteExpendingService
    {
        Task<ExpendingDTO> DeleteExpending(ExpendingDTO expending);
    }
}