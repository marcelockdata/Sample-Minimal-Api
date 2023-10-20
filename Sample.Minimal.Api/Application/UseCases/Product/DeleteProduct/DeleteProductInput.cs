using MediatR;

namespace Sample.Minimal.Api.Application.UseCases.Product.DeleteProduct;

public class DeleteProductInput : IRequest<Unit>
{
    public DeleteProductInput(Guid id)
        => Id = id;

    public Guid Id { get; set; }
}
