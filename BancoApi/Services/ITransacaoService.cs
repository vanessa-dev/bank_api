using BancoApi.Entities;

namespace BancoApi.Services;

public interface ITransacaoService
{
    public Task<IList<Transacao>> GetAll(int idconta);
    public Task<Transacao> GetByID(int id);
    public Task Create(Transacao transacao);
    public Task Update(Transacao transacao);
    public Task Delete(int id);
}