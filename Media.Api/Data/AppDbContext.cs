using System.Reflection;
using Media.Api.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Media.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
    : base(options) { }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
