using BancoApi.Data;
using BancoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDBContext _dbContext;

    public UserRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IList<User>> findAll()
    {
        var context = await _dbContext.Users.ToListAsync();
        
        return context;
    }

    public async Task<User> findById(Guid id)
    {
        var context = await _dbContext.Users.FindAsync(id);
        return context;
    }
    
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task createUser(User User)
    {
        await _dbContext.Users.AddAsync(User);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task updateUser(User User)
    {
        _dbContext.Users.Update(User);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task deleteUser(Guid id)
    {
        var context = await _dbContext.Users.FindAsync(id);
        if (context != null)
        {
            _dbContext.Users.Remove(context);
            await _dbContext.SaveChangesAsync();
        }
    }
}