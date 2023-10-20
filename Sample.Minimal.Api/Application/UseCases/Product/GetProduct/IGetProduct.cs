using MediatR;

namespace Sample.Minimal.Api.Application.UseCases.Product.GetProduct;

public interface IGetProduct : IRequestHandler<GetProductInput, GetProductOutput> { }

