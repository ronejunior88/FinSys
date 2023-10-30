using AutoMapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Command.UpdateExpendingCommand
{
    public class UpdateExpendingCommandHandler : IRequestHandler<UpdateExpendingCommand>
    {
        IConfiguration _configuration;
        IUpdateExpendingService _command;
        IMapper _mapper;

        public UpdateExpendingCommandHandler(IConfiguration configuration, IUpdateExpendingService command, IMapper mapper)
        {
            _configuration = configuration;
            _command = command;
            _mapper = mapper;
        }

        public async Task Handle(UpdateExpendingCommand request, CancellationToken cancellationToken)
        {
            var commandMap = _mapper.Map<ExpendingDTO>(request);
            await _command.UpdateExpending(commandMap);
        }
    }
}
