using Template.Core.Models;
using Template.Core.Repositories.StorageModels;

namespace Template.Core.Repositories.Mappers;

internal static class ProductMapper
{
    public static Product ToProduct(this ProductEntity entity)
    {
        return new Product(
            entity.Name,
            entity.Description ?? string.Empty,
            entity.Price,
            entity.StockQuantity)
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }

    public static ProductEntity ToEntity(this Product product)
    {
        return new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
} 