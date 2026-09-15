using API.Clientes.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Clientes.Repositories;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");
            entity.HasKey(cliente => cliente.Id);
            entity.Property(cliente => cliente.NumeroIdentificacion).HasMaxLength(30).IsRequired();
            entity.Property(cliente => cliente.Nombres).HasMaxLength(100).IsRequired();
            entity.Property(cliente => cliente.Apellidos).HasMaxLength(100).IsRequired();
            entity.Property(cliente => cliente.Email).HasMaxLength(150).IsRequired();
            entity.Property(cliente => cliente.Telefono).HasMaxLength(30);
            entity.Property(cliente => cliente.FechaCreacion).HasColumnType("datetime2").IsRequired();
            entity.HasIndex(cliente => cliente.NumeroIdentificacion).IsUnique();
        });
    }
}
