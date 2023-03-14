using FinSys.Command.Domain;
using MediatR;

namespace FinSys.Command.Interfaces
{
    public interface IAddExpendingCommand
    {
        Task<Unit> AddExpendingAsync(ExpendingCommand command);
    }
}
