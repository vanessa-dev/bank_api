using BancoApi.Entities;

namespace BancoApi.Repositories;

public interface IClientRepository
{
    public Task<IList<Client>> FindAllAsync();
    public Task<Client> FindByIdAsync(Guid id);
    public Task CreateAsync(Client client);
    public Task UpdateAsync(Client client);
    public Task DeleteAsync(Guid id);
}