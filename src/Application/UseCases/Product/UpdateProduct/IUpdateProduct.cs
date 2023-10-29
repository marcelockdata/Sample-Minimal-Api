using MediatR;

namespace Sample.Minimal.Api.Application.UseCases.Product.UpdateProduct;

public interface IUpdateProduct : IRequestHandler<UpdateProductInput, UpdateProductOutput> { }
