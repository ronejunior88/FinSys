using MediatR;

namespace FinSys.Command.UpdateSystemUserCommand
{
    public class UpdateSystemUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
