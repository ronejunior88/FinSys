using FinSys.Query.Interfaces;
using MediatR;

namespace FinSys.Query.Queries.GetExpendingsById
{
    public class GetExpendingsByIdHandler : IRequestHandler<GetExpendingsById, GetExpendingsByIdResponse>, IGetExpendingsById
    {
        IGetExpendingService _getExpendingService;

        public GetExpendingsByIdHandler(IGetExpendingService getExpendingService)
        {
            _getExpendingService = getExpendingService;
        }

        public async Task<GetExpendingsByIdResponse> Handle(GetExpendingsById request, CancellationToken cancellationToken)
        {
            return await _getExpendingService.GetExpendingByIdAsync(request);
        }
    }
}
