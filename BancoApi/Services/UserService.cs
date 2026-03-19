using BancoApi.Entities;
using BancoApi.Exceptions;
using BancoApi.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BancoApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUserRepository repository, IPasswordHasher<User> passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<IList<User>> GetAll()
    {
        return await _repository.FindAllAsync();
    }
    
    public async Task<User> GetByID(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task Create(User User)
    {
        
        var userExist = await _repository.FindByEmailAsync(User.Email);
        
        if (userExist != null)
            throw new Exception("Erro ao cadastrar usuário");

        var user = new User(User.Email, User.Password, User.Name);
        
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        user.Validate();
        await _repository.CreateAsync(user);
    }

    public async Task Update(User User)
    {
        await _repository.UpdateAsync(User);
    }
    
    public async Task Delete(Guid id) 
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<User?> Login(string email, string password)
    {
        var userExist = await _repository.FindByEmailAsync(email);
        
        if (userExist == null)
            throw new Exception("Erro ao autenticar o usuario.");
        
        var result = _passwordHasher.VerifyHashedPassword(userExist, userExist.Password, password);
        if (result == PasswordVerificationResult.Failed)
            return null;
        
        return userExist;
    }
}