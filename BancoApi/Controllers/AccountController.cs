using BancoApi.Entities;
using BancoApi.Requests;
using BancoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{

    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Account>>> Get()
    {
        var contas = await _accountService.GetAll();
        return Ok(contas);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetByID(Guid id)
    {
        var conta = await _accountService.GetByID(id);
        if (conta == null)
            return NotFound();
        return Ok(conta);
    }

    [HttpPost]
    public async Task<ActionResult<Account>> Post([FromBody] AccountRequest accountRequest)
    {
        var account = accountRequest.ToEntity();
        await _accountService.Create(account);
        return CreatedAtAction(nameof(GetByID), new { id = account.Id }, account);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] AccountRequest accountRequest)
    {
        var account = accountRequest.ToEntity();
        await _accountService.Update(account);
        return NoContent();
    }
    
}