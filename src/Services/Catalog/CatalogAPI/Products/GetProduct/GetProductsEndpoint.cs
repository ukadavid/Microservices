
using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.GetProduct
{
    public class GetProductsEndpoint : ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductDTO>();
                return Results.Ok(response);
            })
                .WithName("Get Product")
                .Produces<GetProductDTO>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product")
                .WithDescription("Get Product");
        }
    }
}
