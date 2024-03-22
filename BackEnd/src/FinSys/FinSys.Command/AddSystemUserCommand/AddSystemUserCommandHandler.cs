using AutoMapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Command.AddSystemUserCommand
{
    public class AddSystemUserCommandHandler : IRequestHandler<AddSystemUserCommand>
    {
        IConfiguration _configuration;
        IAddSystemUserService _service;
        IMapper _mapper;

        public AddSystemUserCommandHandler(IConfiguration configuration, IMapper mapper, IAddSystemUserService service)
        {
            _configuration = configuration;
            _mapper = mapper;
            _service = service;
        }

        public async Task Handle(AddSystemUserCommand request, CancellationToken cancellationToken)
        {
            var serviceMap = _mapper.Map<SystemUserDTO>(request);
            await _service.AddSystemUser(serviceMap);
        }
    }
}
