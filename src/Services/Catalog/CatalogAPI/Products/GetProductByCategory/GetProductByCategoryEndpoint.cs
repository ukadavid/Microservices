
using CatalogAPI.Products.GetProduct;

namespace CatalogAPI.Products.GetProductByCategory
{
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
           app.MapGet("/product/get-category/{category}", async (string category, ISender sender) =>
           {
               var result = await sender.Send(new GetProductsByCategoryQuery(category));
               var response = result.Adapt<GetProductByCategoryDTO>();
               return Results.Ok(response);
           })
                .WithName("Get Product By Category")
                .Produces<GetProductDTO>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Category")
                .WithDescription("Get Product By Category");
        }
    }
}
