namespace CatalogAPI.Products.GetProduct
{
    public class GetProductDTO
    {
        public IEnumerable<Product> Products { get; set; }

        public GetProductDTO(IEnumerable<Product> products)
        {
            Products = products;
        }  
    }
}
