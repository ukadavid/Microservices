using BuildingBlocks.CQRS;
using CatalogAPI.Models;
using MediatR;

namespace CatalogAPI.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, int Price) : ICommand<CreateProductResponseDTO>;


    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponseDTO>
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

            return new CreateProductResponseDTO(Guid.NewGuid());
        }
    }   
}
