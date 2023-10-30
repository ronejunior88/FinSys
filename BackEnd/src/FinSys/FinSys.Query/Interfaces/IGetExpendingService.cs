using FinSys.Query.Domain;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;

namespace FinSys.Query.Interfaces
{
    public interface IGetExpendingService
    {
        Task<IEnumerable<GetExpendingsAllResponse>> GetExpendingsAllAsync();
        Task<GetExpendingsByIdResponse> GetExpendingByIdAsync(GetExpendingsById _command);
        Task<IEnumerable<Expending>> GetExpendingByValueAsync(double value);
    }
}
