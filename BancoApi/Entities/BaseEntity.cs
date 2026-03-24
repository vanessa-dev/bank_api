namespace BancoApi.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    /* Toda entidade precisa se auto validar. Isso evita necessidade de multiplas exceções */
    internal List<string> _errors = new();

    public IReadOnlyCollection<string> Errors => _errors;
    public abstract bool Validate();
}
