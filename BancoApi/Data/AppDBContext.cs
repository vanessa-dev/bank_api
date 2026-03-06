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
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
            .HasColumnType("binary(16)")
            .HasConversion(
                v => v.ToByteArray(),
                v => new Guid(v)
            );
        });
        
        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.ToTable("Transacoes");
        });
        
    }

}