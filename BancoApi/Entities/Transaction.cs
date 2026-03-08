using BancoApi.Enums;

namespace BancoApi.Entities;

public class Transaction
{
    
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Descricao { get; set; }
    public DateTime Data { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public TransactionType Tipo { get; set; }
    public decimal Valor { get; set; }
    public Guid IdContaDestino { get; set; }
    public Guid IdContaOrigem { get; set; }
}