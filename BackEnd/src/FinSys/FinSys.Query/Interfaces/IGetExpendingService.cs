using FinSys.Query.Domain;

namespace FinSys.Query.Interfaces
{
    public interface IGetExpendingService
    {
        Task<IEnumerable<Expending>> GetExpendingAsync();
        Task<Expending> GetExpendingByIdAsync(Guid id);
        Task<IEnumerable<Expending>> GetExpendingByValueAsync(double value);
    }
}
