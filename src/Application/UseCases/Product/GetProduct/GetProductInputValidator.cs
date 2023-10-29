using FluentValidation;

namespace Sample.Minimal.Api.Application.UseCases.Product.GetProduct;

public class GetProductInputValidator
 : AbstractValidator<GetProductInput>
{
    public GetProductInputValidator()
        => RuleFor(x => x.Id).NotEmpty();
}
