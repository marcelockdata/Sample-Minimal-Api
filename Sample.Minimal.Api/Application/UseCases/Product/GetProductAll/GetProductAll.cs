using Sample.Minimal.Api.Domain.Interfaces;
using DomainEntity = Sample.Minimal.Api.Domain.Entities;

namespace Sample.Minimal.Api.Application.UseCases.Product.GetProductAll;

public class GetProductAll : IGetProductAll
{
    private readonly IRepository<DomainEntity.Product> _repository;

    public GetProductAll(IRepository<DomainEntity.Product> repository)
        => (_repository) = (repository);

    public async Task<IReadOnlyList<GetProductAllOutput>> Handle(GetProductAllInput request, CancellationToken cancellationToken)
    {
        var productList = await _repository.GetAll();

        return GetProductAllOutput.FromProductList(productList);
    }
}
