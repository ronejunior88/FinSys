using FinSys.Query.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetExpendingsAll
{
    public class GetExpendingsAllHandler : IRequestHandler<GetExpendingsAll, IEnumerable<GetExpendingsAllResponse>>, IGetExpendingsAll
    {
        IGetExpendingService _getExpendingService;
        public GetExpendingsAllHandler(IGetExpendingService getExpendingService)
        {
            _getExpendingService = getExpendingService;
        }
        public async Task<IEnumerable<GetExpendingsAllResponse>> Handle(GetExpendingsAll request, CancellationToken cancellationToken)
        {
            return _getExpendingService.GetExpendingsAllAsync().Result.Skip((request.Page - 1) * request.NumberRow).Take(request.NumberRow);
        }
    }
}
