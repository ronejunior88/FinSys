using FinSys.Query.Domain;
using FinSys.Query.Queries.GetExpendingsAll;

namespace FinSys.Query.Interfaces
{
    public interface IGetExpendingService
    {
        Task<IEnumerable<GetExpendingsAllResponse>> GetExpendingsAllAsync();
        Task<Expending> GetExpendingByIdAsync(Guid id);
        Task<IEnumerable<Expending>> GetExpendingByValueAsync(double value);
    }
}
