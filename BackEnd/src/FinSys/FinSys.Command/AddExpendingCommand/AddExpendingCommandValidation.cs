using FluentValidation;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommandValidation : AbstractValidator<AddExpendingCommand>
    {
        public AddExpendingCommandValidation()
        {
            RuleFor(command => command.Value)
             .NotEmpty().WithMessage("O valor não pode ser vazio")
             .NotNull().WithMessage("O valor não pode ser nulo")
             .Must(value => IsValidDouble(value)).WithMessage("O valor do double pode ser até 18 antes da virgula e 2 depois da virgula");
        }


        private bool IsValidDouble(double? value)
        {
            return value.HasValue && value <= 18 && value == 2;
        }
    }
}