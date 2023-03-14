using FinSys.Command.Domain;
using FinSys.Command.Interfaces;
using MediatR;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommand : IAddExpendingCommand
    {
        public Task<Unit> AddExpendingAsync(ExpendingCommand command)
        {
            throw new NotImplementedException();
        }
    }
}