using BancoApi.Entities;
using BancoApi.Enums;

namespace BancoApi.Requests;

public class TransacaoRequest
{
    public string Descricao { get; set; }
    public DateTime Data { get; set; } 
    public TipoTransacao Tipo { get; set; }
    public decimal Valor { get; set; }
    public Guid IdContaDestino { get; set; }
    public Guid IdContaOrigem { get; set; }

    public Transacao ToEntity()
    {
        return new Transacao
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
