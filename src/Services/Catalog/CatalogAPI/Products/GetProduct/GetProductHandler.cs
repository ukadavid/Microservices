
namespace CatalogAPI.Products.GetProduct
{

    public record GetProductsQuery() : IQuery<GetProductDTO>;
    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductDTO>
    {
        async Task<GetProductDTO> IRequestHandler<GetProductsQuery, GetProductDTO>.Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

            var product = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductDTO(product);
        }
    }
}
