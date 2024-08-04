

namespace CatalogAPI.Products.CreateProduct
{
    public class CreateProductEndPoint : ICarterModule
    {
         void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/product", async (CreateProductDTO request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponseDTO>();
                return Results.Created($"/product/{response.id}", response);
            })
                .WithName("Create Product")
                .Produces<CreateProductResponseDTO>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");

        }
    }
}
