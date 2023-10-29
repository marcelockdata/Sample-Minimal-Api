using MediatR;
using Sample.Minimal.Api.Application.Interfaces;
using Sample.Minimal.Api.Domain.Interfaces;
using DomainEntity = Sample.Minimal.Api.Domain.Entities;

namespace Sample.Minimal.Api.Application.UseCases.Product.DeleteProduct;

public class DeleteProduct : IDeleteProduct
{
    private readonly IRepository<DomainEntity.Product> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProduct(IRepository<DomainEntity.Product> repository, IUnitOfWork unitOfWork)
        => (_repository, _unitOfWork) = (repository, unitOfWork);

    public async Task<Unit> Handle(DeleteProductInput input, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(input.Id, cancellationToken);
        ////NotFoundException.ThrowIfNull(product, $"Product '{input.Id}' not found.");
        await _repository.Delete(product!);
        await _unitOfWork.Commit(cancellationToken);
        return Unit.Value;
    }
}
