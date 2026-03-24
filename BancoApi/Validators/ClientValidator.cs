using BancoApi.Entities;
using FluentValidation;

namespace BancoApi.Validators;

public class ClientValidator : AbstractValidator<Client>
{
    public ClientValidator()
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