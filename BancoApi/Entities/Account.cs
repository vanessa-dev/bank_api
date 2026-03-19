using BancoApi.Exceptions;
using BancoApi.Validators;

namespace BancoApi.Entities;

public class Account : BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public decimal Saldo  { get; set; }
    
    public override bool Validate()
    {
        var validator = new AccountValidator();
        var validation = validator.Validate(this);

        if(!validation.IsValid){
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new DomainException("Invalid Fields", _errors);
        }

        return true;
    }
}