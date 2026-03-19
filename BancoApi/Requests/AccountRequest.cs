using BancoApi.Entities;

namespace BancoApi.Requests;

public class AccountRequest
{
    public string Nome { get; set; }
    
    public Account ToEntity()
    {
        return new Account
        {
            Nome =  Nome
        };
    }
}