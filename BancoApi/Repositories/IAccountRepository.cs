using BancoApi.Entities;
using BancoApi.Requests;

namespace BancoApi.Repositories;

public interface IAccountRepository
{
    public Task<IList<Account>> FindAllAsync();
    public Task<Account> FindByIdAsync(Guid id);
    public Task CreateAsync(Account account);
    public Task UpdateAsync(Account account);
    public Task DeleteAsync(Guid id);
}