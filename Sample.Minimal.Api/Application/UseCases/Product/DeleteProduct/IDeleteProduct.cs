using MediatR;

namespace Sample.Minimal.Api.Application.UseCases.Product.DeleteProduct;

public interface IDeleteProduct
    : IRequestHandler<DeleteProductInput, Unit>
{ }
