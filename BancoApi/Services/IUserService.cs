using BancoApi.Entities;

namespace BancoApi.Services;

public interface IUserService
{
    public Task<IList<User>> GetAll();
    public Task<User> GetByID(Guid id);
    public Task Create(User user);
    public Task Update(User user);
    public Task Delete(Guid id);
    public Task<User?> Login(string email, string password);
}