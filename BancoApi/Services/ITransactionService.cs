using BancoApi.Entities;

namespace BancoApi.Services;

public interface ITransactionService
{
    public Task<IList<Transaction>> GetAll(Guid idconta);
    public Task<Transaction> GetByID(Guid id);
    public Task Create(Transaction transaction);
}