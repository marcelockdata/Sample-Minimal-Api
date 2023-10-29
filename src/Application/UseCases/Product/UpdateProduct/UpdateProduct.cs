using Sample.Minimal.Api.Application.Interfaces;
using Sample.Minimal.Api.Domain.Interfaces;
using DomainEntity = Sample.Minimal.Api.Domain.Entities;

namespace Sample.Minimal.Api.Application.UseCases.Product.UpdateProduct;

public class UpdateProduct : IUpdateProduct
{
    private readonly IRepository<DomainEntity.Product> _repository;
    private readonly IUnitOfWork _uinitOfWork;

    public UpdateProduct(
        IRepository<DomainEntity.Product> repository,
        IUnitOfWork uinitOfWork)
        => (_uinitOfWork, _repository)
            = (uinitOfWork, repository);

    public async Task<UpdateProductOutput> Handle(UpdateProductInput input, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(input.ProductId, cancellationToken);
        ////NotFoundException.ThrowIfNull(product, $"Produto '{input.ProductId}' not found.");
        product!.Update(input.Name, input.Description, input.Price);

        if (input.IsActive!) product.Activate();
        else product.Deactivate();

        await _repository.Update(product);
        await _uinitOfWork.Commit(cancellationToken);
        return UpdateProductOutput.FromProduct(product);
    }
}

