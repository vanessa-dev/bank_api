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
    
    public async Task<IList<User>> FindAllAsync()
    {
        var context = await _dbContext.Users.ToListAsync();
        
        return context;
    }

    public async Task<User> FindByIdAsync(Guid id)
    {
        var context = await _dbContext.Users.FindAsync(id);
        return context;
    }
    
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task CreateAsync(User User)
    {
        await _dbContext.Users.AddAsync(User);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(User User)
    {
        _dbContext.Users.Update(User);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(Guid id)
    {
        var context = await _dbContext.Users.FindAsync(id);
        if (context != null)
        {
            _dbContext.Users.Remove(context);
            await _dbContext.SaveChangesAsync();
        }
    }
}