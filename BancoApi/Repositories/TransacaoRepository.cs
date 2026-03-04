using BancoApi.Data;
using BancoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly AppDBContext _dbContext;

    public TransacaoRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IList<Transacao>> findAll(int idconta)
    {
        var context =  await _dbContext.Transacoes
            .Where(t => t.IdConta == idconta)
            .ToListAsync();;
        
        return context;
    }

    public async Task<Transacao> findById(int id)
    {
        var context = await _dbContext.Transacoes.FindAsync(id);
        return context;
    }

    public async Task createTransacao(Transacao transacao)
    {
        await _dbContext.Transacoes.AddAsync(transacao);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task updateTransacao(Transacao transacao)
    {
        _dbContext.Transacoes.Update(transacao);
        await _dbContext.SaveChangesAsync();
    }

    public async Task deleteTransacao(int id)
    {
        var context = await _dbContext.Transacoes.FindAsync(id);
        if (context != null)
        {
            _dbContext.Transacoes.Remove(context);
            await _dbContext.SaveChangesAsync();
        }
    }
}