using FinSys.Command.Domain;
using FinSys.Command.Interfaces;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommand : IAddExpendingCommand, IRequest<AddExpendingCommandRequest>
    {
        IConfiguration _configuration;
        IAddExpendingService _service;

        public AddExpendingCommand(IConfiguration configuration, IAddExpendingService service)
        {
            _configuration = configuration;
            _service = service;
        }

        public async Task AddExpendingAsync(AddExpendingCommandRequest command)
        {
            await _service.AddExpending(command);
        }
    }
}