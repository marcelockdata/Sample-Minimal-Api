using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Sample.Minimal.Api.Infra;

[ExcludeFromCodeCoverage]
public class AppDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Port=25432;Database=database-dev;User Id=admin;Password=123456;");
        return new AppDbContext(optionsBuilder.Options);
    }
}
