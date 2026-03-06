using BancoApi.Data;
using BancoApi.Entities;
using BancoApi.Requests;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly AppDBContext _dbContext;

    public TransacaoRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IList<Transacao>> findAll(Guid idconta)
    {
        var context =  await _dbContext.Transacoes
            .Where(t => t.IdContaOrigem == idconta
                        || t.IdContaDestino == idconta)
            .OrderByDescending(t => t.Data)
            .ToListAsync();
        
        return context;
    }

    public async Task<Transacao> findById(Guid id)
    {
        var context = await _dbContext.Transacoes.FindAsync(id);
        return context;
    }

    public async Task createTransacao(Transacao transacao)
    {
        await _dbContext.Transacoes.AddAsync(transacao);
        await _dbContext.SaveChangesAsync();
        
    }
}