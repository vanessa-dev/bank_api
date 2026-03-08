using BancoApi.Entities;
using BancoApi.Enums;

namespace BancoApi.Requests;

public class TransactionRequest
{
    public string Descricao { get; set; }
    public DateTime Data { get; set; } 
    public TransactionType Tipo { get; set; }
    public decimal Valor { get; set; }
    public Guid IdContaDestino { get; set; }
    public Guid IdContaOrigem { get; set; }

    public Transaction ToEntity()
    {
        return new Transaction
        {
            Valor = Valor,
            Descricao = Descricao,
            Tipo = Tipo,
            Data = Data,
            IdContaDestino = IdContaDestino,
            IdContaOrigem = IdContaOrigem
        };
    }
}
