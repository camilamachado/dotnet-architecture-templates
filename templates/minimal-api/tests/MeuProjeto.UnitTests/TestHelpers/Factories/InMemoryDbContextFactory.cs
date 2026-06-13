using MeuProjeto.Infrastructure.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MeuProjeto.UnitTests.TestHelpers.Factories;

public static class InMemoryDbContextFactory
{
    public static MeuProjetoDbContext CreateContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<MeuProjetoDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new MeuProjetoDbContext(options);

        context.Database.EnsureCreated();

        return context;
    }
}
