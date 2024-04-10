using FinSys.Command.Domain;
using MediatR;

namespace FinSys.Command.UpdateSystemUserCommand
{
    public class UpdateSystemUserCommand : IRequest<UserToken>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
