using BancoApi.Entities;

namespace BancoApi.Repositories;

public interface IUserRepository
{
    public Task<IList<User>> findAll();
    public Task<User> findById(Guid id);
    public Task<User?> FindByEmailAsync(string email);
    public Task createUser(User user);
    public Task updateUser(User user);
    public Task deleteUser(Guid id);
}