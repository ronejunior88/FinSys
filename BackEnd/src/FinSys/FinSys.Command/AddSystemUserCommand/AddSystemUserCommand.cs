﻿using FinSys.Command.Domain;
using MediatR;

namespace FinSys.Command.AddSystemUserCommand
{
    public class AddSystemUserCommand : IRequest<UserToken>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
