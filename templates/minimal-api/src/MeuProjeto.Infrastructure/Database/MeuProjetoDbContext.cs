using MeuProjeto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.Infrastructure.Database;

public class MeuProjetoDbContext(DbContextOptions<MeuProjetoDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuProjetoDbContext).Assembly);

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        => configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(255);
}
