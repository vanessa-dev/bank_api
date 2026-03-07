using BancoApi.Enums;
using Microsoft.AspNetCore.Identity;

namespace BancoApi.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Status Status { get; set; } = Status.Active;
    public string Password { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; } = Role.Client;
    
}