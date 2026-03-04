using BancoApi.Entities;

namespace BancoApi.Repositories;

public interface ITransacaoRepository
{
    public Task<IList<Transacao>> findAll(int idconta);
    public Task<Transacao> findById(int id);
    public Task createTransacao(Transacao transacao);
    public Task updateTransacao(Transacao transacao);
    public Task deleteTransacao(int id);
}