using BancoApi.Entities;

namespace BancoApi.Repositories;

public interface ITransacaoRepository
{
    public Task<IList<Transacao>> findAll();
    public Task<Transacao> findById(int id);
    public Task createTransacao(Conta conta, Transacao transacao);
    public Task updateTransacao(Conta conta, Transacao transacao);
    public Task deleteTransacao(int id);
}