using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Core.Common;
using Template.Core.Models;
using Template.Core.Services;

namespace Template.Core.CQRS.Queries
{
    /// <summary>
    /// Query for retrieving a product by ID
    /// </summary>
    public class GetProductQuery : IRequest<Result<Product>>
    {
        public Guid Id { get; }

        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }

    /// <summary>
    /// Handler for GetProductQuery
    /// </summary>
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<Product>>
    {
        private readonly IProductService _productService;

        public GetProductQueryHandler(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<Result<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductByIdAsync(request.Id);
        }
    }
} 