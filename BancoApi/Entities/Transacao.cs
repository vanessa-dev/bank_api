using BancoApi.Enums;

namespace BancoApi.Entities;

public class Transacao
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public TipoTransacao Tipo { get; set; }
    public decimal Valor { get; set; }
    public int IdConta { get; set; }
}