using Sample.Minimal.Api.Application.Interfaces;

namespace Sample.Minimal.Api.Infra;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
        => _context = context;

    public Task Commit(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);

    public Task Rollback(CancellationToken cancellationToken)
        => Task.CompletedTask;
}

