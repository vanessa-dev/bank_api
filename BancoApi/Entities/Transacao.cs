using BancoApi.Enums;

namespace BancoApi.Entities;

public class Transacao
{

    public Transacao()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public TipoTransacao Tipo { get; set; }
    public decimal Valor { get; set; }
    public Guid IdContaDestino { get; set; }
    public Guid IdContaOrigem { get; set; }
}