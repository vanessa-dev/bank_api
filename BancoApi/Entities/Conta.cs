namespace BancoApi.Entities;

public class Conta
{
    public Conta()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    public string Nome { get; set; }
}