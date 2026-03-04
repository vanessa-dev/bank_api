using BancoApi.Entities;
using BancoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContasController : ControllerBase
{

    private readonly IContaService _contaService;

    public ContasController(IContaService contaService)
    {
        _contaService = contaService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Conta>>> Get()
    {
        var contas = await _contaService.GetAll();
        return Ok(contas);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Conta>> GetByID(int id)
    {
        var conta = await _contaService.GetByID(id);
        if (conta == null)
            return NotFound();
        return Ok(conta);
    }

    [HttpPost]
    public async Task<ActionResult<Conta>> Post([FromBody] Conta conta)
    {
        await _contaService.Create(conta);
        return CreatedAtAction(nameof(GetByID), new { id = conta.Id }, conta);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Conta contaRequest)
    {
        await _contaService.Update(contaRequest);
        return NoContent();
    }
    
}