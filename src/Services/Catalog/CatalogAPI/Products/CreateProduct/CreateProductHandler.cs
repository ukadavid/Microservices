using BuildingBlocks.CQRS;
using MediatR;

namespace CatalogAPI.Products.CreateProduct
{

    public record CreateProductCommand(CreateProductDTO CreateProductRequest) : ICommand<CreateProductResult>;
    
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        Task<CreateProductResult> IRequestHandler<CreateProductCommand, CreateProductResult>.Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            
        }
    }   
}
