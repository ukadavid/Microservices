

namespace CatalogAPI.Products.GetProductById
{
    public record GetProductsByIdQuery(Guid id) : IQuery<GetProductByIdDTO>;
    internal class GetProductByIdHandler (IDocumentSession session, ILogger<GetProductsByIdQuery> logger) : IQueryHandler<GetProductsByIdQuery, GetProductByIdDTO>
    {
        public async Task<GetProductByIdDTO> Handle(GetProductsByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }
                

            return new GetProductByIdDTO(product);
        }
    }
}
