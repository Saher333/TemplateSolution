using Template.Core.Common;
using Template.Core.Models;

namespace Template.Core.Interfaces;

/// <summary>
/// Service interface for Product operations
/// </summary>
public interface IProductService
{
    Task<Result<Product>> GetProductByIdAsync(Guid id);
    Task<Result<IEnumerable<Product>>> GetAllProductsAsync();
    Task<Result<Product>> CreateProductAsync(string name, string description, decimal price, int stockQuantity);
    Task<Result<Product>> UpdateProductAsync(Guid id, string name, string description, decimal price, int stockQuantity);
    Task<Result<bool>> DeleteProductAsync(Guid id);
    Task<Result<Product>> UpdateStockAsync(Guid id, int newQuantity);
}
