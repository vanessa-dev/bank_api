using BancoApi.Entities;
using BancoApi.Requests;
using BancoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;

    public TransacoesController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }
    
    [HttpGet("{idconta}")]
    public async Task<ActionResult<List<Transacao>>> Get(Guid idconta)
    {
        var transacaos = await _transacaoService.GetAll(idconta);
        return Ok(transacaos);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Transacao>> GetByID(Guid id)
    {
        var transacoes = await _transacaoService.GetByID(id);
        if (transacoes == null)
            return NotFound();
        
        return Ok(transacoes);
    }
    
    [HttpPost]
    public async Task<ActionResult<Transacao>> Post([FromBody] TransacaoRequest transacaoRequest)
    {
        var transacao = transacaoRequest.ToEntity();
        await _transacaoService.Create(transacao);
        return CreatedAtAction(nameof(GetByID), new { id = transacao.Id }, transacao);
    }
    
}