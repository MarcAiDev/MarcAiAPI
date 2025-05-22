using FluentValidation;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Service.Validators
{
    public class StoreValidator : AbstractValidator<StoreEntity>
    {
        public StoreValidator()
        {
            RuleFor(s => s.StoreName)
                .NotEmpty().WithMessage("Nome da loja é obrigatório.")
                .MaximumLength(255).WithMessage("Nome da loja não pode exceder 255 caracteres.");

            RuleFor(s => s.StoreDescription)
                .MaximumLength(1000).WithMessage("Descrição não pode exceder 1000 caracteres.")
                .When(s => true);
        }
    }
}