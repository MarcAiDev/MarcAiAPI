using FluentValidation;
using MarcAiAPI.Domain.Entities.Address;

namespace MarcAiAPI.Service.Validators
{
    public class AddressValidator : AbstractValidator<StoreAddressEntity>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("Rua é obrigatória.")
                .MaximumLength(255).WithMessage("Rua não pode exceder 255 caracteres.");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("Cidade é obrigatória.")
                .MaximumLength(100).WithMessage("Cidade não pode exceder 100 caracteres.");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("Estado é obrigatório.")
                .MaximumLength(100).WithMessage("Estado não pode exceder 100 caracteres.");
        }
    }
}