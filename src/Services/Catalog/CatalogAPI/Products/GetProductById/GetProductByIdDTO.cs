namespace CatalogAPI.Products.GetProductById
{
    public class GetProductByIdDTO
    {
        public GetProductByIdDTO() { } 

        public GetProductByIdDTO(Product product)
        {
            Name = product.Name;
            Category = product.Category;
            Description = product.Description;
            ImageFile = product.ImageFile;
            Price = product.Price;
        }

        public string Name { get; set; }
        public List<string> Category { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}

