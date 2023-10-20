using MediatR;

namespace Sample.Minimal.Api.Application.UseCases.Product.GetProductAll;

public interface IGetProductAll : IRequestHandler<GetProductAllInput, IReadOnlyList<GetProductAllOutput>> { }

