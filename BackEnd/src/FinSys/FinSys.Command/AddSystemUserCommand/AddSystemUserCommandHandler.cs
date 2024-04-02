using AutoMapper;
using FinSys.Command.Domain;
using FinSys.Command.Interfaces;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;
using System.Web.Http.Results;

namespace FinSys.Command.AddSystemUserCommand
{
    public class AddSystemUserCommandHandler : IRequestHandler<AddSystemUserCommand, UserToken>
    {
        IConfiguration _configuration;
        IAddSystemUserService _service;
        IAuthenticate _authenticateService;
        IMapper _mapper;

        public AddSystemUserCommandHandler(IConfiguration configuration, IMapper mapper, IAddSystemUserService service, IAuthenticate authenticateService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _service = service;
            _authenticateService = authenticateService;
        }

        public async Task<UserToken> Handle(AddSystemUserCommand request, CancellationToken cancellationToken)
        {
            var serviceMap = _mapper.Map<SystemUserDTO>(request);
            await _service.AddSystemUser(serviceMap);

            var token = _authenticateService.GenerateToken(request.Id, request.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
