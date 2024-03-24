using AutoMapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Command.UpdateSystemUserCommand
{
    public class UpdateSystemUserCommandHandler : IRequestHandler<UpdateSystemUserCommand>
    {
        IConfiguration _configuration;
        IUpdateSystemUseService _command;
        IMapper _mapper;

        public UpdateSystemUserCommandHandler(IConfiguration configuration, IUpdateSystemUseService command, IMapper mapper)
        {
            _configuration = configuration;
            _command = command;
            _mapper = mapper;
        }


        public async Task Handle(UpdateSystemUserCommand request, CancellationToken cancellationToken)
        {
            var commandMap = _mapper.Map<SystemUserDTO>(request);
            await _command.UpdateSystemUser(commandMap);
        }
    }
}
