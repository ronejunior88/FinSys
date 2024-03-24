using FluentValidation;

namespace FinSys.Command.AddSystemUserCommand
{
    public class AddSystemUserCommandValidation : AbstractValidator<AddSystemUserCommand>
    {
        public AddSystemUserCommandValidation()
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
