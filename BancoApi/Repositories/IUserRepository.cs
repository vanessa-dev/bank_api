using BancoApi.Entities;

namespace BancoApi.Repositories;

public interface IUserRepository
{
    public Task<IList<User>> FindAllAsync();
    public Task<User> FindByIdAsync(Guid id);
    public Task<User?> FindByEmailAsync(string email);
    public Task CreateAsync(User user);
    public Task UpdateAsync(User user);
    public Task DeleteAsync(Guid id);
}