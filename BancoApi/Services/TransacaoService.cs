using BancoApi.Entities;
using BancoApi.Repositories;

namespace BancoApi.Services;

public class TransacaoService : ITransacaoService
{
    public readonly ITransacaoRepository _repository;
    public TransacaoService(ITransacaoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IList<Transacao>> GetAll(Guid idconta)
    {
        return await _repository.findAll(idconta);
    }
    
    public async Task<Transacao> GetByID(Guid id)
    {
        return await _repository.findById(id);
    }

    public async Task Create(Transacao transaco)
    {
        await _repository.createTransacao(transaco);
    }
    
}