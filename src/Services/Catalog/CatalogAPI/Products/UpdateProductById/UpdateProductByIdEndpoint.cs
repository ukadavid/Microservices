
using CatalogAPI.Products.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Products.UpdateProductById
{
    public class UpdateProductByIdEndpoint : ICarterModule
    {
        void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/product/update/{id}", async (Guid id, UpdateProductDTO request, ISender sender) =>
            {
              
                var command = new UpdateProductIdCommand(
                    id: id,
                    Name: request?.Name,
                    Category: request?.Category,
                    Description: request?.Description,
                    ImageFile: request?.ImageFile,
                    Price: request.Price.HasValue ? (int)request.Price : 0 
                );

                var result = await sender.Send(command);

                return Results.Ok(result);

            })
                 .WithName("Update Product")
                .Produces<GetProductDTO>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Update Product")
                .WithDescription("Update Product");
        }
    }
}
