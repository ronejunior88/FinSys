using FinSys.Query.Queries.GetExpendingsById;
using FinSys.Query.Queries.GetSystemUserAll;
using FinSys.Query.Queries.GetSystemUserById;

namespace FinSys.Query.Interfaces
{
    public interface IGetSystemUserService
    {
        Task<IEnumerable<GetSystemUserAllResponse>> GetSystemUsersAllAsync();

        Task<GetSystemUserByIdResponse> GetSystemUsersByIdAsync(GetSystemUserById Id);
    }
}
