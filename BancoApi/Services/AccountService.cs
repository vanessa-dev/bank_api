using BancoApi.Entities;
using BancoApi.Repositories;

namespace BancoApi.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IList<Account>> GetAll()
    {
        return await _repository.FindAllAsync();
    }
    
    public async Task<Account> GetByID(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task Create(Account account)
    {
        await _repository.CreateAsync(account);
    }

    public async Task Update(Account account)
    {
        await _repository.UpdateAsync(account);
    }
    
    public async Task Delete(Guid id) 
    {
        await _repository.DeleteAsync(id);
    }
}