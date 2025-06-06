using Template.Core.Common;
using Template.Core.Constants;
using Template.Core.Interfaces;
using Template.Core.Models;

namespace Template.Core.Services;

/// <summary>
/// Implementation of IProductService
/// </summary>
public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

    public async Task<Result<Product>> GetProductByIdAsync(Guid id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null 
                ? Result<Product>.Failure(ErrorMessages.ProductNotFound)
                : Result<Product>.Success(product);
        }
        catch (Exception)
        {
            return Result<Product>.Failure(ErrorMessages.DatabaseError);
        }
    }

    public async Task<Result<IEnumerable<Product>>> GetAllProductsAsync()
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            return Result<IEnumerable<Product>>.Success(products);
        }
        catch (Exception)
        {
            return Result<IEnumerable<Product>>.Failure(ErrorMessages.DatabaseError);
        }
    }

    public async Task<Result<Product>> CreateProductAsync(string name, string description, decimal price, int stockQuantity)
    {
        var validationErrors = new List<string>();
        
        if (string.IsNullOrWhiteSpace(name))
            validationErrors.Add(ErrorMessages.ProductNameRequired);
        
        if (price <= 0)
            validationErrors.Add(ErrorMessages.ProductPriceInvalid);

        if (validationErrors.Count > 0)
            return Result<Product>.ValidationFailure(validationErrors);

        try
        {
            var product = new Product(name, description, price, stockQuantity);
            await _productRepository.AddAsync(product);
            return Result<Product>.Success(product);
        }
        catch (Exception)
        {
            return Result<Product>.Failure(ErrorMessages.DatabaseError);
        }
    }

    public async Task<Result<Product>> UpdateProductAsync(Guid id, string name, string description, decimal price, int stockQuantity)
    {
        var validationErrors = new List<string>();
        
        if (string.IsNullOrWhiteSpace(name))
            validationErrors.Add(ErrorMessages.ProductNameRequired);
        
        if (price <= 0)
            validationErrors.Add(ErrorMessages.ProductPriceInvalid);

        if (validationErrors.Count > 0)
            return Result<Product>.ValidationFailure(validationErrors);

        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return Result<Product>.Failure(ErrorMessages.ProductNotFound);

            product.Update(name, description, price, stockQuantity);
            await _productRepository.UpdateAsync(product);
            return Result<Product>.Success(product);
        }
        catch (Exception)
        {
            return Result<Product>.Failure(ErrorMessages.DatabaseError);
        }
    }

    public async Task<Result<bool>> DeleteProductAsync(Guid id)
    {
        try
        {
            if (!await _productRepository.ExistsAsync(id))
                return Result<bool>.Failure(ErrorMessages.ProductNotFound);

            await _productRepository.DeleteAsync(id);
            return Result<bool>.Success(true);
        }
        catch (Exception)
        {
            return Result<bool>.Failure(ErrorMessages.DatabaseError);
        }
    }

    public async Task<Result<Product>> UpdateStockAsync(Guid id, int newQuantity)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return Result<Product>.Failure(ErrorMessages.ProductNotFound);

            product.UpdateStock(newQuantity);
            await _productRepository.UpdateAsync(product);
            return Result<Product>.Success(product);
        }
        catch (Exception)
        {
            return Result<Product>.Failure(ErrorMessages.DatabaseError);
        }
    }
}
