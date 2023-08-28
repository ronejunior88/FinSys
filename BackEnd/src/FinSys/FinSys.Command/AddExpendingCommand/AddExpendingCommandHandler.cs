using AutoMapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommandHandler : IRequestHandler<AddExpendingCommand>
    {
        IConfiguration _configuration;
        IAddExpendingService _command;
        IMapper _mapper;
        public AddExpendingCommandHandler(IConfiguration configuration, IMapper mapper ,IAddExpendingService command)
        {
            _configuration = configuration;
            _mapper = mapper;
            _command = command;
        }

        public async Task Handle(AddExpendingCommand request, CancellationToken cancellationToken)
        {
            await _command.AddExpending(_mapper.Map<ExpendingDTO>(request));
        }
    }
}
