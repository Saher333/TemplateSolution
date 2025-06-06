using MediatR;
using Template.Core.Common;
using Template.Core.CQRS.Queries.Models;
using Template.Core.Interfaces;
using Template.Core.Models;

namespace Template.Core.CQRS.Queries;

/// <summary>
/// Handler for GetProductQuery
/// </summary>
public class GetProductQueryHandler(IProductService productService) : IRequestHandler<GetProductQuery, Result<Product>>
{
    private readonly IProductService _productService = productService ?? throw new ArgumentNullException(nameof(productService));

    public async Task<Result<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetProductByIdAsync(request.Id);
    }
}
