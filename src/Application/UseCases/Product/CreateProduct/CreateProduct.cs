﻿using Sample.Minimal.Api.Application.Interfaces;
using Sample.Minimal.Api.Domain.Interfaces;
using DomainEntity = Sample.Minimal.Api.Domain.Entities;

namespace Sample.Minimal.Api.Application.UseCases.Product.CreateProduct;

public class CreateProduct : ICreateProduct
{
    private readonly IRepository<DomainEntity.Product> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProduct(IRepository<DomainEntity.Product> repository, IUnitOfWork unitOfWork)
        => (_repository, _unitOfWork) = (repository, unitOfWork);

    public async Task<CreateProductOutput> Handle(CreateProductInput input, CancellationToken cancellationToken)
    {
        var product = new DomainEntity.Product(
            Guid.NewGuid(),
            input.Name,
            input.Description,
            input.Price,
            input.IsActive,
            DateTime.Now
         );

        await _repository.Add(product);
        await _unitOfWork.Commit(cancellationToken);

        return await Task.FromResult(CreateProductOutput.FromProduct(product));
    }
}
