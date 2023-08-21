using FinSys.Command.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommandHandler : IRequestHandler<AddExpendingCommandRequest>
    {
        IConfiguration _configuration;
        IAddExpendingCommand _command;
        public AddExpendingCommandHandler(IConfiguration configuration,IAddExpendingCommand command)
        {
            _configuration = configuration;
            _command = command;
        }

        public async Task Handle(AddExpendingCommandRequest request, CancellationToken cancellationToken)
        {
            await _command.AddExpendingAsync(request);
        }
    }
}
