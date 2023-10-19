using FinSys.Query.Domain;

namespace FinSys.Query.Interfaces
{
    public interface IGetExpendingService
    {
        Task<IEnumerable<Expending>> GetExpendingAsync();
    }
}
