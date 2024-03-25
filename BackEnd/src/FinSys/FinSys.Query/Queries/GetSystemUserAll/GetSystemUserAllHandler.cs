using FinSys.Query.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetSystemUserAll
{
    public class GetSystemUserAllHandler : IRequestHandler<GetSystemUserAll, IEnumerable<GetSystemUserAllResponse>>, IGetSystemUserAll
    {
        IGetSystemUserService _getSystemUserService;

        public GetSystemUserAllHandler(IGetSystemUserService getSystemUserService)
        {
            _getSystemUserService = getSystemUserService;
        }

        public async Task<IEnumerable<GetSystemUserAllResponse>> Handle(GetSystemUserAll request, CancellationToken cancellationToken)
        {
            return await _getSystemUserService.GetSystemUsersAllAsync();
        }
    }
}
