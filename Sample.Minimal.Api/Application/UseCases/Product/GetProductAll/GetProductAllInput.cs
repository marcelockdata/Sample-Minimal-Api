using MediatR;

namespace Sample.Minimal.Api.Application.UseCases.Product.GetProductAll;

public class GetProductAllInput : IRequest<IReadOnlyList<GetProductAllOutput>> { }
