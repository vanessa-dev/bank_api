using BancoApi.Data;
using BancoApi.Entities;
using BancoApi.Requests;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDBContext _dbContext;

    public TransactionRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IList<Transaction>> FindAllAsync(Guid idconta)
    {
        var context =  await _dbContext.Transacoes
            .Where(t => t.IdContaOrigem == idconta
                        || t.IdContaDestino == idconta)
            .OrderByDescending(t => t.Data)
            .ToListAsync();
        
        return context;
    }

    public async Task<Transaction> FindByIdAsync(Guid id)
    {
        var context = await _dbContext.Transacoes.FindAsync(id);
        return context;
    }

    public async Task CreateAsync(Transaction transaction)
    {
        await _dbContext.Transacoes.AddAsync(transaction);
        await _dbContext.SaveChangesAsync();
        
    }
}