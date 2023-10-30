using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;

namespace FinSys.Query.Interfaces
{
    public interface IGetExpendingService
    {
        Task<IEnumerable<GetExpendingsAllResponse>> GetExpendingsAllAsync();
        Task<GetExpendingsByIdResponse> GetExpendingByIdAsync(GetExpendingsById request);
        Task<IEnumerable<GetExpendingByValueResponse>> GetExpendingByValueAsync(GetExpendingByValue request);
    }
}
