using BancoApi.Entities;

namespace BancoApi.Services;

public interface IClientService
{
    public Task<IList<Client>> GetAll();
    public Task<Client> GetByID(Guid id);
    public Task Create(Client client);
    public Task Update(Client client);
    public Task Delete(Guid id);
}