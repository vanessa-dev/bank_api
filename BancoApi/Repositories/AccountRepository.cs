using BancoApi.Data;
using BancoApi.Entities;
using BancoApi.Requests;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDBContext _dbContext;

    public AccountRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IList<Account>> FindAllAsync()
    {
        var context = await _dbContext.Contas.ToListAsync();
        
        return context;
    }

    public async Task<Account> FindByIdAsync(Guid id)
    {
        var context = await _dbContext.Contas.FindAsync(id);
        return context;
    }

    public async Task CreateAsync(Account account)
    {
        await _dbContext.Contas.AddAsync(account);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(Account account)
    {
        _dbContext.Contas.Update(account);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(Guid id)
    {
        var context = await _dbContext.Contas.FindAsync(id);
        if (context != null)
        {
             _dbContext.Contas.Remove(context);
             await _dbContext.SaveChangesAsync();
        }
    }
}