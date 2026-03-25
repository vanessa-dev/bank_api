using BancoApi.Entities;

namespace BancoApi.Requests;

public class ClientRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public Guid? UserId { get; set; }
    
    public Client ToEntity()
    {
        return new Client
        {
            Nome = Nome.Trim(),
            Documento = Documento.Trim(),
            UserId = UserId
        };
    }
}
