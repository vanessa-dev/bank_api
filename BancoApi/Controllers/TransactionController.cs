using BancoApi.Entities;
using BancoApi.Requests;
using BancoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

[ApiController]
[Route("api/transaction")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    
    [HttpGet("{idconta}")]
    public async Task<ActionResult<List<Transaction>>> Get(Guid idconta)
    {
        var transacaos = await _transactionService.GetAll(idconta);
        return Ok(transacaos);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetByID(Guid id)
    {
        var transacoes = await _transactionService.GetByID(id);
        if (transacoes == null)
            return NotFound();
        
        return Ok(transacoes);
    }
    
    [HttpPost]
    public async Task<ActionResult<Transaction>> Post([FromBody] TransactionRequest transactionRequest)
    {
        var transacao = transactionRequest.ToEntity();
        await _transactionService.Create(transacao);
        return CreatedAtAction(nameof(GetByID), new { id = transacao.Id }, transacao);
    }
    
}