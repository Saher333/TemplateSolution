using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Template.Core.Common;
using Template.Core.Models;
using Template.Core.Services;

namespace Template.Core.CQRS.Commands
{
    /// <summary>
    /// Command for creating a new product
    /// </summary>
    public class CreateProductCommand : IRequest<Result<Product>>
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int StockQuantity { get; }

        public CreateProductCommand(string name, string description, decimal price, int stockQuantity)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }

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
} 