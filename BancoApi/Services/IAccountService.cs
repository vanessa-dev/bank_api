using BancoApi.Entities;

namespace BancoApi.Services;

public interface IAccountService
{
    public Task<IList<Account>> GetAll();
    public Task<Account> GetByID(Guid id);
    public Task Create(Account account);
    public Task Update(Account account);
    public Task Delete(Guid id);
}