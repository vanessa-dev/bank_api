using BancoApi.Entities;
using FluentValidation;

namespace BancoApi.Validators;

public class TransactionValidator : AbstractValidator<Transaction>
{
    public TransactionValidator()
    {
        RuleFor(entity => entity)
            .NotEmpty()
            .WithMessage("entity invalid")
            .NotNull()
            .WithMessage("entity invalid");
        RuleFor(entity => entity.Descricao)
            .NotEmpty()
            .WithMessage("descricao is required")
            .NotNull()
            .WithMessage("descricao is required");
    }
}