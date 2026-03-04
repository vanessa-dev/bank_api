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
    
    public async Task<IList<Transacao>> GetAll(int idconta)
    {
        return await _repository.findAll(idconta);
    }
    
    public async Task<Transacao> GetByID(int id)
    {
        return await _repository.findById(id);
    }

    public async Task Create(Transacao transaco)
    {
        await _repository.createTransacao(transaco);
    }

    public async Task Update(Transacao transacao)
    {
        await _repository.updateTransacao(transacao);
    }
    
    public async Task Delete(int id) 
    {
        await _repository.deleteTransacao(id);
    }
}