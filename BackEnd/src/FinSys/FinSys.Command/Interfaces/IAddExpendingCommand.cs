using FinSys.Command.AddExpendingCommand;
using FinSys.Command.Domain;
using MediatR;

namespace FinSys.Command.Interfaces
{
    public interface IAddExpendingCommand
    {
        Task AddExpendingAsync(AddExpendingCommandRequest command);
    }
}
