using BancoApi.Entities;
using BancoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Client>>> Get()
    {
        var contas = await _clientService.GetAll();
        return Ok(contas);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetByID(Guid id)
    {
        var conta = await _clientService.GetByID(id);
        if (conta == null)
            return NotFound();
        return Ok(conta);
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Post([FromBody] Client client)
    {
        await _clientService.Create(client);
        return CreatedAtAction(nameof(GetByID), new { id = client.Id }, client);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] Client clientRequest)
    {
        await _clientService.Update(clientRequest);
        return NoContent();
    }
}