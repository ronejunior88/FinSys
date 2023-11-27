using MediatR;
using Newtonsoft.Json;
using System.Globalization;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommand : IRequest
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public bool Inative { get; set; }
        public DateTime DateExpiration { get; set; }
        public DateTime DateRelease { get; set; }
        public DateTime? DatePayment { get; set; }
    }
}