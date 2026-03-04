using BancoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Data;

public class AppDBContext  : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Conta> Contas => Set<Conta>();
    public DbSet<Transacao> Transacoes => Set<Transacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.ToTable("Contas");
        });
        
        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.ToTable("Transacoes");
            entity.Property(e => e.Tipo)
                .HasConversion<string>();
        });
        
    }

}