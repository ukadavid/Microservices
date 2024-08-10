using BuildingBlocks.CQRS;
using CatalogAPI.Models;
using MediatR;

namespace CatalogAPI.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, int Price) : ICommand<CreateProductResponseDTO>;


    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResponseDTO>
    {
        public async Task<CreateProductResponseDTO> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,

            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResponseDTO(product.Id);
        }
    }   
}
