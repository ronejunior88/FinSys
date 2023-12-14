using FinSys.Command.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Command.UploadExpendingCommand
{
    public class UploadExpendingCommand : IRequest
    {
        public UploadExpendingCommand()
        {
            this.Expendings = new List<Expending>();
        }

        public List<Expending> Expendings { get; set; }
        public string Name { get; set; }
        public DateTime DateUpload { get; set; }
        public long NumberLines { get; set; }
    }
}
