using BancoApi.Entities;

namespace BancoApi.Repositories;

public interface ITransacaoRepository
{
    public Task<IList<Transacao>> findAll(Guid idconta);
    public Task<Transacao> findById(Guid id);
    public Task createTransacao(Transacao transacao);
}