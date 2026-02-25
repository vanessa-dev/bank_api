using BancoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Data;

public class AppDBContext  : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Conta> Contas => Set<Conta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.ToTable("Contas");
        });
        
    }

}