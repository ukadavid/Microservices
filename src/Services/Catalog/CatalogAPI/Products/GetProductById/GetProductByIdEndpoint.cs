
using CatalogAPI.Products.GetProduct;

namespace CatalogAPI.Products.GetProductById
{
    public class GetProductByIdEndpoint : ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductsByIdQuery(id));
                var response = result.Adapt<GetProductByIdDTO>();
                return Results.Ok(response);
            })
                .WithName("Get Product By Id")
                .Produces<GetProductDTO>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Id")
                .WithDescription("Get Product By Id");
        }
    }
}
