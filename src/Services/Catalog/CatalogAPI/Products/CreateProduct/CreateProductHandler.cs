using BuildingBlocks.CQRS;
using MediatR;

namespace CatalogAPI.Products.CreateProduct
{

    public record CreateProductCommand(CreateProductDTO CreateProductRequest) : ICommand<CreateProductResult>;
    
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.CreateProductRequest.Name,
                Category = command.CreateProductRequest.Category,
                Description = command.CreateProductRequest.Description,
                ImageFile = command.CreateProductRequest.ImageFile,
                Price = command.CreateProductRequest.Price,

            };

            return new CreateProductResponseDTO(Guid.NewGuid());
        }
    }   
}
