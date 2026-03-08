namespace BancoApi.Entities;

public class Account
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
}