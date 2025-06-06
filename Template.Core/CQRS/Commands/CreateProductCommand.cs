using MediatR;
using Template.Core.Common;
using Template.Core.CQRS.Commands.Models;
using Template.Core.Interfaces;
using Template.Core.Models;

namespace Template.Core.CQRS.Commands;

/// <summary>
/// Handler for CreateProductCommand
/// </summary>
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Product>>
{
    private readonly IProductService _productService;

    public CreateProductCommandHandler(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    public async Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productService.CreateProductAsync(
            request.Name,
            request.Description,
            request.Price,
            request.StockQuantity);
    }
}
