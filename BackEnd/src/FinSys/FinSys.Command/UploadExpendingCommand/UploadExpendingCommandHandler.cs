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
        IUploadExpendingService _command;
        IMapper _mapper;

        public UploadExpendingCommandHandler(IConfiguration configuration, IMapper mapper, IUploadExpendingService command)
        {
            _configuration = configuration;
            _mapper = mapper;
            _command = command;
        }

        public async Task Handle(UploadExpendingCommand request, CancellationToken cancellationToken)
        {
            
            var commandMap = _mapper.Map<IEnumerable<ExpendingDTO>>(request.Expendings);
            await _command.AddUploadExpending(commandMap.ToList());
        }
    }
}
