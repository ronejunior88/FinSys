using FinSys.Query.Interfaces;
using MediatR;

namespace FinSys.Query.Queries.GetExpendingByValue
{
    public class GetExpendingByValueHandler : IRequestHandler<GetExpendingByValue, IEnumerable<GetExpendingByValueResponse>>, IGetExpendingByValue
    {
        IGetExpendingService _getExpendingService;

        public GetExpendingByValueHandler(IGetExpendingService getExpendingService)
        {
            _getExpendingService = getExpendingService;
        }

        public async Task<IEnumerable<GetExpendingByValueResponse>> Handle(GetExpendingByValue request, CancellationToken cancellationToken)
        {
            return _getExpendingService.GetExpendingByValueAsync(request).Result.Skip((request.Page - 1) * request.NumberRow).Take(request.NumberRow);
        }
    }
}
