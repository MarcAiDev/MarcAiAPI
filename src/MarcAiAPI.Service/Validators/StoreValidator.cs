using FluentValidation;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Service.Validators
{
    public class StoreValidator : AbstractValidator<StoreEntity>
    {
        public StoreValidator()
        {
            RuleFor(s => s.Cnpj)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .MaximumLength(20).WithMessage("O CNPJ deve ter no máximo 20 caracteres.");

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(s => s.Description)
                .MaximumLength(255).WithMessage("A descrição deve ter no máximo 255 caracteres.");

            RuleFor(s => s.Status)
                .MaximumLength(50).WithMessage("O status deve ter no máximo 50 caracteres.");

            RuleFor(s => s.Category)
                .MaximumLength(50).WithMessage("A categoria deve ter no máximo 50 caracteres.");

            RuleFor(s => s.SubCategory)
                .MaximumLength(50).WithMessage("A subcategoria deve ter no máximo 50 caracteres.");

            RuleFor(s => s.SellerId)
                .NotEmpty().WithMessage("O SellerId é obrigatório.");

            RuleFor(s => s.MarketplaceId)
                .NotEmpty().WithMessage("O MarketplaceId é obrigatório.");
        }
    }
}