﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Command.UpdateSystemUserCommand
{
    public class UpdateSystemUserCommandValidation : AbstractValidator<UpdateSystemUserCommand>
    {
        public UpdateSystemUserCommandValidation()
        {
            RuleFor(command => command.Name)
             .NotEmpty().WithMessage("O nome não pode estar vazio")
             .NotNull().WithMessage("O nome não pode estar nulo");

            RuleFor(command => command.DateBirth)
                 .NotEmpty().WithMessage("A data de nascimento não pode estar vazia")
                 .NotNull().WithMessage("A data de nascimento não pode estar nula");
        }
    }
}
