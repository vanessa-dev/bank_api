using BancoApi.Entities;
using BancoApi.Repositories;

namespace BancoApi.Services;

public class TransactionService : ITransactionService
{
    public readonly ITransactionRepository _repository;
    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IList<Transaction>> GetAll(Guid idconta)
    {
        return await _repository.FindAllAsync(idconta);
    }
    
    public async Task<Transaction> GetByID(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task Create(Transaction transaco)
    {
        await _repository.CreateAsync(transaco);
    }
    
}