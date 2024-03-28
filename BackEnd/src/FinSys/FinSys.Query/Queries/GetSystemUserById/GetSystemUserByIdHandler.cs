using FinSys.Query.Interfaces;
using MediatR;

namespace FinSys.Query.Queries.GetSystemUserById
{
    public class GetSystemUserByIdHandler : IRequestHandler<GetSystemUserById, GetSystemUserByIdResponse>, IGetSystemUserById
    {
        IGetSystemUserService _getSystemUserService;

        public GetSystemUserByIdHandler(IGetSystemUserService getSystemUserService)
        {
            _getSystemUserService = getSystemUserService;
        }

        public async Task<GetSystemUserByIdResponse> Handle(GetSystemUserById request, CancellationToken cancellationToken)
        {
            return await _getSystemUserService.GetSystemUsersByIdAsync(request);
        }
    }
}
