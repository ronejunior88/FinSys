using AutoMapper;
using FinSys.Command.Domain;
using FinSys.Command.Interfaces;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommand : IAddExpendingCommand
    {
        IConfiguration _configuration;
        IAddExpendingService _service;
        IMapper _mapper;

        public AddExpendingCommand()
        {  }

        public AddExpendingCommand(IConfiguration configuration, IAddExpendingService service, IMapper mapper)
        {
            _configuration = configuration;
            _service = service;
            _mapper = mapper;
        }

        public async Task AddExpendingAsync(AddExpendingCommandRequest command)
        {
            await _service.AddExpending(_mapper.Map<ExpendingDTO>(command));
        }
    }
}