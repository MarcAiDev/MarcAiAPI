using FluentValidation;
using MarcAiAPI.Domain.Entities.User;

namespace MarcAiAPI.Service.Validators
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("PersonId é obrigatório.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome completo é obrigatório.")
                .MaximumLength(100)
                .WithMessage("Nome completo deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .MaximumLength(50)
                .WithMessage("Email deve ter no máximo 50 caracteres.")
                .EmailAddress()
                .WithMessage("Email inválido.");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11)
                .WithMessage("Telefone deve ter no máximo 11 caracteres.");

            RuleFor(x => x.DateOfBirth)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Data de nascimento não pode ser no futuro.");
        }
    }
}