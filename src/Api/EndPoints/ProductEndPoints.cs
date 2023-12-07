using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Minimal.Api.Api.ApiModels;
using Sample.Minimal.Api.Api.ApiModels.Product;
using Sample.Minimal.Api.Application.UseCases.Product.CreateProduct;
using Sample.Minimal.Api.Application.UseCases.Product.DeleteProduct;
using Sample.Minimal.Api.Application.UseCases.Product.GetProduct;
using Sample.Minimal.Api.Application.UseCases.Product.GetProductAll;
using Sample.Minimal.Api.Application.UseCases.Product.UpdateProduct;

namespace Sample.Minimal.Api.Api.EndPoints;

public static class ProductEndPoints
{
    public static void ConfigureProductEndpoints(this WebApplication app)
    {
        app.MapPost("/api/products", 
            static async (IMediator mediator, 
                [FromBody] CreateProductInput input, 
                CancellationToken cancellationToken)
            =>
        {
            var output = await mediator.Send(input, cancellationToken);
            return Results.Created($"/api/products/{output.ProductId}", new ApiResponse<CreateProductOutput>(output));
        })
        .WithName("CreateProduct")
        .Accepts<CreateProductInput>("application/json")
        .Produces<ApiResponse<CreateProductOutput>>(StatusCodes.Status201Created)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
        .Produces<ProblemDetails>(StatusCodes.Status422UnprocessableEntity);

        app.MapGet("/api/products/{id:guid}", 
            static async (IMediator mediator, 
                [FromRoute] Guid id, 
                CancellationToken cancellationToken)
           =>
        {
            var output = await mediator.Send(new GetProductInput(id), cancellationToken);
            return Results.Ok(new ApiResponse<GetProductOutput>(output));

        })
       .WithName("GetProduct")
       .Produces<ApiResponse<GetProductOutput>>(StatusCodes.Status200OK)
       .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

        app.MapPut("/api/products/{id:guid}",
            static async (IMediator mediator,
                [FromBody] UpdateProductApiInput apiInput,
                [FromRoute] Guid id,
                CancellationToken cancellationToken)
          =>
        {
            var input = new UpdateProductInput(
                  id,
                  apiInput.Name,
                  apiInput.Description,
                  apiInput.Price,
                  apiInput.IsActive);

            var output = await mediator.Send(input, cancellationToken);
            return Results.Ok(new ApiResponse<UpdateProductOutput>(output));

        })
      .WithName("UpdateProduct")
      .Produces<ApiResponse<UpdateProductOutput>>(StatusCodes.Status200OK)
      .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

        app.MapDelete("/api/products/{id:guid}", 
            static async (IMediator mediator, 
                [FromRoute] Guid id, 
                CancellationToken cancellationToken)
          =>
        {
            var output = await mediator.Send(new DeleteProductInput(id), cancellationToken);
            return Results.NoContent();

        })
      .WithName("DeleteProduct")
      .Produces(StatusCodes.Status204NoContent)
      .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

        app.MapGet("/api/products", 
            static async (IMediator mediator, 
                CancellationToken cancellationToken)
          =>
        {
            var output = await mediator.Send(new GetProductAllInput(), cancellationToken);
            return Results.Ok(new ApiResponseList<GetProductAllOutput>(output));

        })
      .WithName("GetProductAll")
      .Produces<ApiResponseList<GetProductAllOutput>>(StatusCodes.Status200OK)
      .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);
    }
}
