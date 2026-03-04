using BancoApi.Entities;

namespace BancoApi.Services;

public interface ITransacaoService
{
    public decimal Saldo(Conta conta);
    public void Saque(Conta conta);
    public void Depositar(Conta conta);
}