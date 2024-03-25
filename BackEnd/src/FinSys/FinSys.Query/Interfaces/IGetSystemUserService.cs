using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetSystemUserAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Interfaces
{
    public interface IGetSystemUserService
    {
        Task<IEnumerable<GetSystemUserAllResponse>> GetSystemUsersAllAsync();
    }
}
