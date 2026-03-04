namespace BancoApi.Entities;

public class Transacao
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public string Tipo { get; set; }
    public decimal Valor { get; set; }
    public int IdEmpresa { get; set; }
}