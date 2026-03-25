using BancoApi.Exceptions;
using BancoApi.Validators;

namespace BancoApi.Entities;

public class Client : BaseEntity
{
    public Client()
    {
        Id = Guid.NewGuid();
    }

    public string Nome { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public Guid?  UserId { get; set; }

    public override bool Validate()
    {
        _errors.Clear();

        var validator = new ClientValidator();
        var validation = validator.Validate(this);

        if(!validation.IsValid){
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new DomainException("Invalid Fields", _errors);
        }

        return true;
    }
}
