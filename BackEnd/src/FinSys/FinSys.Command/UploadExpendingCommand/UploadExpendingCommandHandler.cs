using AutoMapper;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Command.UploadExpendingCommand
{
    public class UploadExpendingCommandHandler : IRequestHandler<UploadExpendingCommand>
    {
        IConfiguration _configuration;
        IAddExpendingService _command;
        IMapper _mapper;

        public UploadExpendingCommandHandler(IConfiguration configuration, IMapper mapper, IAddExpendingService command)
        {
            _configuration = configuration;
            _mapper = mapper;
            _command = command;
        }

        public async Task Handle(UploadExpendingCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Expendings)
            {
                var commandMap = _mapper.Map<ExpendingDTO>(item);
                await _command.AddExpending(commandMap);
            }
            
        }
    }
}
