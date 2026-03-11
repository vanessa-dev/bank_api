using System.Security.Claims;
using BancoApi.Requests;
using BancoApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Controllers;

[ApiController, Route("api/auth")]
public class AuthController(
    IUserService _userService,
    TokenService _tokenService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var user = await _userService.Login(loginRequest.Email, loginRequest.Password);
        if (user is null)
            return Unauthorized("Credenciais inválidas");

        var token = _tokenService.GenerateToken(user);
        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me() =>
        Ok(new {
            id    = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            email = User.FindFirst(ClaimTypes.Email)?.Value,
            role  = User.FindFirst(ClaimTypes.Role)?.Value
        });
}