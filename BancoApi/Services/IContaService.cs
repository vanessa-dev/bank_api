using BancoApi.Entities;

namespace BancoApi.Services;

public interface IContaService
{
    public Task<IList<Conta>> GetAll();
    public Task<Conta> GetByID(int id);
    public Task Create(Conta conta);
    public Task Update(Conta conta);
    public Task Delete(int id);
}