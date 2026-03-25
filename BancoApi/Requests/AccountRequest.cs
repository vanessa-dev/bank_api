using BancoApi.Entities;

namespace BancoApi.Requests;

public class AccountRequest
{
    public string Nome { get; set; } = string.Empty;
    public Guid ClientId { get; set; }
    
    public Account ToEntity()
    {
        return new Account
        {
            Nome = Nome.Trim(),
            ClientId = ClientId,
            Saldo = 0
        };
    }
}
