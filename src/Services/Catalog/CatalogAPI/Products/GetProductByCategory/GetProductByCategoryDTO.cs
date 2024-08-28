namespace CatalogAPI.Products.GetProductByCategory
{
    public class GetProductByCategoryDTO
    {
        public GetProductByCategoryDTO() { }

        public IEnumerable<Product> Products { get; set; }

        public GetProductByCategoryDTO(IEnumerable<Product> products)
        {
            Products = products;
        }
    }

}

