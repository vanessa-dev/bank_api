using BancoApi.Entities;
using BancoApi.Repositories;

namespace BancoApi.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IList<Client>> GetAll()
    {
        return await _repository.FindAllAsync();
    }
    
    public async Task<Client> GetByID(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task Create(Client client)
    {
        await _repository.CreateAsync(client);
    }

    public async Task Update(Client client)
    {
        await _repository.UpdateAsync(client);
    }
    
    public async Task Delete(Guid id) 
    {
        await _repository.DeleteAsync(id);
    }
}