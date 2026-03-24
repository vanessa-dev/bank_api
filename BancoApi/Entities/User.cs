using BancoApi.Enums;
using BancoApi.Exceptions;
using BancoApi.Validators;

namespace BancoApi.Entities;

public class User : BaseEntity
{
    
    public User(string email, string password, string name)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Name = name;
    }
    
    public Status Status { get; set; } = Status.Active;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.Client;
    public string Name { get; set; } = string.Empty;

    public override bool Validate()
    {
        _errors.Clear();

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
