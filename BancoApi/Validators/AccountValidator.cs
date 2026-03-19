using BancoApi.Entities;
using FluentValidation;

namespace BancoApi.Validators;

public class AccountValidator : AbstractValidator<Account>
{
    public AccountValidator()
    {
        RuleFor(entity => entity)
            .NotEmpty()
            .WithMessage("entity invalid")
            .NotNull()
            .WithMessage("entity invalid");

        RuleFor(entity => entity.Nome)
            .NotEmpty()
            .WithMessage("name is required")
            .NotNull()
            .WithMessage("name is required");
    }
        
}