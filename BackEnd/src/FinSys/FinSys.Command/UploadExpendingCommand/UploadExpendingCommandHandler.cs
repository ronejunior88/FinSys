using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Command.UploadExpendingCommand
{
    public class UploadExpendingCommandHandler : IRequestHandler<UploadExpendingCommand>
    {
        public Task Handle(UploadExpendingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
