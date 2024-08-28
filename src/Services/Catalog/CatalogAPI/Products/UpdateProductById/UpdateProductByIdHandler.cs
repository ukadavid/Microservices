


namespace CatalogAPI.Products.UpdateProductById
{
    public record UpdateProductIdCommand(Guid id, string Name, List<string> Category, string Description, string ImageFile, int Price) : ICommand<Guid>;

    internal class UpdateProductByIdHandler(IDocumentSession session, ILogger<UpdateProductIdCommand> logger) : ICommandHandler<UpdateProductIdCommand, Guid>
    {
         async Task<Guid> IRequestHandler<UpdateProductIdCommand, Guid>.Handle(UpdateProductIdCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description; 
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);

            await session.SaveChangesAsync(cancellationToken);

            return command.id;

        }
       
    }
}
