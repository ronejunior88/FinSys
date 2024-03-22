using MediatR;

namespace FinSys.Command.AddSystemUserCommand
{
    public class AddSystemUserCommand : IRequest
    {
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
