using MediatR;

namespace FinSys.Command.UpdateSystemUserCommand
{
    public class UpdateSystemUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
