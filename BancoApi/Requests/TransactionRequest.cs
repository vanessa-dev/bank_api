using BancoApi.Entities;
using BancoApi.Enums;

namespace BancoApi.Requests;

public class TransactionRequest
{
    public string Descricao { get; set; } = string.Empty;
    public TransactionType Tipo { get; set; }
    public decimal Valor { get; set; }
    public Guid? IdContaDestino { get; set; }
    public Guid? IdContaOrigem { get; set; }

    public Transaction ToEntity()
    {
        return new Transaction
        {
            Valor = Valor,
            Descricao = Descricao.Trim(),
            Tipo = Tipo,
            Data = DateTime.UtcNow,
            IdContaDestino = IdContaDestino,
            IdContaOrigem = IdContaOrigem
        };
    }
}
