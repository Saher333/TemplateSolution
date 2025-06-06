using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Core.Models;

namespace Template.Core.Interfaces
{
    /// <summary>
    /// Repository interface for Product operations
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
} 