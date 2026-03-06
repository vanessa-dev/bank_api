using BancoApi.Entities;

namespace BancoApi.Services;

public interface ITransacaoService
{
    public Task<IList<Transacao>> GetAll(Guid idconta);
    public Task<Transacao> GetByID(Guid id);
    public Task Create(Transacao transacao);
}