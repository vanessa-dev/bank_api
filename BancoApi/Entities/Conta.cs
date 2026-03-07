namespace BancoApi.Entities;

public class Conta
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
}