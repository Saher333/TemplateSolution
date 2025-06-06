using MediatR;
using Template.Core.Common;
using Template.Core.Models;

namespace Template.Core.CQRS.Commands.Models;

/// <summary>
/// Command for creating a new product
/// </summary>
public record CreateProductCommand(string Name, string Description, decimal Price, int StockQuantity) : IRequest<Result<Product>>;
