using BancoApi.Entities;
using BancoApi.Requests;

namespace BancoApi.Repositories;

public interface IContaRepository
{
    public Task<IList<Conta>> findAll();
    public Task<Conta> findById(int id);
    public Task createConta(Conta conta);
    public Task updateConta(Conta conta);
    public Task deleteConta(int id);
}