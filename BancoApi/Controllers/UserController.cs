using BancoApi.Entities;
using BancoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetByID(Guid id)
    {
        var users = await _userService.GetByID(id);
        if (users == null)
            return NotFound();
        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post([FromBody] User users)
    {
        await _userService.Create(users);
        return CreatedAtAction(nameof(GetByID), new { id = users.Id }, users);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] User users)
    {
        await _userService.Update(users);
        return NoContent();
    }
}