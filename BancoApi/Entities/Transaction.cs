using BancoApi.Enums;
using BancoApi.Exceptions;
using BancoApi.Validators;

namespace BancoApi.Entities;

public class Transaction : BaseEntity
{
    public Transaction()
    {
        Id = Guid.NewGuid();
        Data = DateTime.UtcNow;
    }

    public string Descricao { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public TransactionType Tipo { get; set; }
    public decimal Valor { get; set; }
    public Guid? IdContaDestino { get; set; }
    public Guid? IdContaOrigem { get; set; }

    public override bool Validate()
    {
        _errors.Clear();
        var validator = new TransactionValidator();
        var validation = validator.Validate(this);

        if(!validation.IsValid){
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new DomainException("Invalid Fields", _errors);
        }

        return true;
    }
}
