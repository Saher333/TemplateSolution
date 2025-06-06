using MediatR;
using Template.Core.Common;
using Template.Core.Models;

namespace Template.Core.CQRS.Queries.Models;

/// <summary>
/// Query for retrieving a product by ID
/// </summary>
public record GetProductQuery(Guid Id) : IRequest<Result<Product>>;
