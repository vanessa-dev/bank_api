using BancoApi.Entities;
using BancoApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContasController: ControllerBase
{

    private readonly IContaRepository _repository;

    public ContasController(IContaRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Conta>>> Get()
    {
        var contas = await _repository.findAll();
        return Ok(contas);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Conta>> GetByID(int id)
    {
        var conta = await _repository.findById(id);
        if (conta == null)
            return NotFound();
        return Ok(conta);
    }

    [HttpPost]
    public async Task<ActionResult<Conta>> Post([FromBody] Conta conta)
    {
        await _repository.createConta(conta);
        return CreatedAtAction(nameof(GetByID), new { id = conta.Id }, conta);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Conta contaRequest)
    {
        await _repository.updateConta(contaRequest);
        return NoContent();
    }
    
}