using Sample.Minimal.Api.Domain.Entities;

namespace Sample.Minimal.Api.Domain.Interfaces;

public interface IRepository<T> where T : IEntidade
{
    Task Add(T entidade);

    Task Update(T entidade);

    Task<T?> GetById(Guid id, CancellationToken cancellationToken);

    Task SaveChanges();

    Task Delete(T entidade);

    Task<IReadOnlyList<T>> GetAll();
}
