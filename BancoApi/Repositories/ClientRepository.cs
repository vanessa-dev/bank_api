using BancoApi.Data;
using BancoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Repositories;

public class ClientRepository :  IClientRepository
{
    private readonly AppDBContext _dbContext;

    public ClientRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IList<Client>> FindAllAsync()
    {
        var context = await _dbContext.Clients.ToListAsync();
        
        return context;
    }

    public async Task<Client> FindByIdAsync(Guid id)
    {
        var context = await _dbContext.Clients.FindAsync(id);
        return context;
    }

    public async Task CreateAsync(Client Client)
    {
        await _dbContext.Clients.AddAsync(Client);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(Client Client)
    {
        _dbContext.Clients.Update(Client);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(Guid id)
    {
        var context = await _dbContext.Clients.FindAsync(id);
        if (context != null)
        {
            _dbContext.Clients.Remove(context);
            await _dbContext.SaveChangesAsync();
        }
    }
}