using BancoApi.Entities;
using BancoApi.Exceptions;
using BancoApi.Repositories;

namespace BancoApi.Services;

public class TransactionService : ITransactionService
{
    public readonly ITransactionRepository _repository;
    public readonly IAccountRepository _accountRepository;
    public TransactionService(ITransactionRepository repository, IAccountRepository accountRepository)
    {
        _repository = repository;
        _accountRepository = accountRepository;
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
        var fromAccount = await _accountRepository.FindByIdAsync(transaco.IdContaOrigem);
        var toAccount = await _accountRepository.FindByIdAsync(transaco.IdContaDestino); 
        
        if (fromAccount == null || toAccount == null)
            throw new Exception("Account not found");

        await _repository.CreateAsync(transaco);
    }
    
}