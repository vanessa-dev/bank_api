using BancoApi.Entities;
using BancoApi.Repositories;

namespace BancoApi.Services;

public class ContaService : IContaService
{
    private readonly IContaRepository _repository;

    public ContaService(IContaRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IList<Conta>> GetAll()
    {
        return await _repository.findAll();
    }
    
    public async Task<Conta> GetByID(int id)
    {
        return await _repository.findById(id);
    }

    public async Task Create(Conta conta)
    {
        await _repository.createConta(conta);
    }

    public async Task Update(Conta conta)
    {
        await _repository.updateConta(conta);
    }
    
    public async Task Delete(int id) 
    {
        await _repository.deleteConta(id);
    }
}