using BancoApi.Enums;
using BancoApi.Exceptions;
using BancoApi.Validators;
using Microsoft.AspNetCore.Identity;

namespace BancoApi.Entities;

public class User : BaseEntity
{
    
    public User(string email, string password, string name)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Name = name;
        _errors = new List<string>();
    }
    
    public Status Status { get; set; } = Status.Active;
    public string Password { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; } = Role.Client;
    public string Name { get; set; }

    public override bool Validate()
    {
        var validator = new UserValidator();
        var validation = validator.Validate(this);

        if(!validation.IsValid){
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new DomainException("Invalid Fields", _errors);
        }

        return true;
    }
    
}