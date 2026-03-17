using BancoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoApi.Data;

public class AppDBContext  : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Account> Contas => Set<Account>();
    public DbSet<Transaction> Transacoes => Set<Transaction>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
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
        
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transacoes");
            entity.Property(e => e.Id)
                .HasColumnType("binary(16)")
                .HasConversion(
                    v => v.ToByteArray(),
                    v => new Guid(v)
                );
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.Property(e => e.Id)
                .HasColumnType("binary(16)")
                .HasConversion(
                    v => v.ToByteArray(),
                    v => new Guid(v)
                );
        });
        
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Clients");
            entity.Property(e => e.Id)
                .HasColumnType("binary(16)")
                .HasConversion(
                    v => v.ToByteArray(),
                    v => new Guid(v)
                );
        });
        
    }

}