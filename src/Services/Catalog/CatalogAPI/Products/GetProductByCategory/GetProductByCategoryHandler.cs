namespace CatalogAPI.Products.GetProductByCategory
{

    public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductByCategoryDTO>;

    internal class GetProductByCategoryHandler (IDocumentSession session, ILogger<GetProductsByCategoryQuery> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductByCategoryDTO>
    {
        public async Task<GetProductByCategoryDTO> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            var product = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync();

            return new GetProductByCategoryDTO(product);
        }
    }
}
