using MediatR;

namespace Sample.Minimal.Api.Application.UseCases.Product.CreateProduct;

public interface ICreateProduct : IRequestHandler<CreateProductInput, CreateProductOutput> { }
