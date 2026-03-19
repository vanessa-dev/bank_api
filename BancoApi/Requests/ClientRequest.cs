using BancoApi.Entities;

namespace BancoApi.Requests;

public class ClientRequest
{
    public string Nome { get; set; }
    
    public Client ToEntity()
    {
        return new Client
        {
            Nome =  Nome
        };
    }
}