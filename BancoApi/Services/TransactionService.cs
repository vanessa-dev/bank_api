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
        Account? fromAccount = null;
        Account? toAccount = null;

        if (transaco.IdContaOrigem.HasValue)
            fromAccount = await _accountRepository.FindByIdAsync(transaco.IdContaOrigem.Value);

        if (transaco.IdContaDestino.HasValue)
            toAccount = await _accountRepository.FindByIdAsync(transaco.IdContaDestino.Value);
        
        if (transaco.IdContaOrigem.HasValue && fromAccount == null)
            throw new Exception("Account not found");

        if (transaco.IdContaDestino.HasValue && toAccount == null)
            throw new Exception("Account not found");

        await _repository.CreateAsync(transaco);
    }
    
}
