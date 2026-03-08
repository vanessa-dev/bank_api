using BancoApi.Entities;

namespace BancoApi.Repositories;

public interface ITransactionRepository
{
    public Task<IList<Transaction>> FindAllAsync(Guid idconta);
    public Task<Transaction> FindByIdAsync(Guid id);
    public Task CreateAsync(Transaction transaction);
}