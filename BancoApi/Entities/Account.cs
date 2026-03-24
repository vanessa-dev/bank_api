using BancoApi.Exceptions;
using BancoApi.Validators;

namespace BancoApi.Entities;

public class Account : BaseEntity
{
    public Account()
    {
        Id = Guid.NewGuid();
    }

    public string Nome { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public decimal Saldo  { get; set; }
    public Guid ClientId { get; set; }
    
    public override bool Validate()
    {
        _errors.Clear();

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
