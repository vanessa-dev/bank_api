using BancoApi.Data;
using BancoApi.Entities;
using BancoApi.Requests;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly AppDBContext _dbContext;

    public ContaRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IList<Conta>> findAll()
    {
        var context = await _dbContext.Contas.ToListAsync();
        
        return context;
    }

    public async Task<Conta> findById(int id)
    {
        var context = await _dbContext.Contas.FindAsync(id);
        return context;
    }

    public async Task createConta(Conta conta)
    {
        await _dbContext.Contas.AddAsync(conta);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task updateConta(Conta conta)
    {
        _dbContext.Contas.Update(conta);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task deleteConta(int id)
    {
        var context = await _dbContext.Contas.FindAsync(id);
        if (context != null)
        {
             _dbContext.Contas.Remove(context);
             await _dbContext.SaveChangesAsync();
        }
    }
}