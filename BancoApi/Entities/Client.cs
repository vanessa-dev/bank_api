namespace BancoApi.Entities;

public class Client
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
}