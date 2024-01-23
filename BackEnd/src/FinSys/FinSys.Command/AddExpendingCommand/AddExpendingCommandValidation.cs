using FluentValidation;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommandValidation : AbstractValidator<AddExpendingCommand>
    {
        public AddExpendingCommandValidation()
        {
            RuleFor(command => command.Value)
             .NotEmpty().WithMessage("O valor não pode estar vazio")
             .NotNull().WithMessage("O valor não pode estar nulo");

             RuleFor(command => command.Value.ToString())
             .Length(2,18).WithMessage("O valor do double pode ser até 18 antes do ponto e 2 depois do ponto");

            RuleFor(command => command.Description)
             .NotEmpty().WithMessage("A descrição não pode estar vazia")
             .NotNull().WithMessage("A descrição não pode estar nula");


            RuleFor(command => command.Inative)
             .NotEmpty().WithMessage("O inativo não pode estar vazio")
             .NotNull().WithMessage("O inativo não pode estar nulo");

            RuleFor(command => command.DateExpiration)
             .NotEmpty().WithMessage("A data de expiração não pode estar vazia")
             .NotNull().WithMessage("O data de expiração não pode estar nula");

            RuleFor(command => command.DateRelease)
             .NotEmpty().WithMessage("A data de emissão não pode estar vazia")
             .NotNull().WithMessage("A data de emissão não pode estar nula");             
        }
    }
}