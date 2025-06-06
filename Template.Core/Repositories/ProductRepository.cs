using Microsoft.EntityFrameworkCore;
using Template.Core.Interfaces;
using Template.Core.Models;
using Template.Core.Repositories.Mappers;
using Template.Core.Repositories.StorageModels;

namespace Template.Core.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<ProductEntity>().FindAsync(id);
            return entity?.ToProduct();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var entities = await _context.Set<ProductEntity>().ToListAsync();
            return entities.Select(e => e.ToProduct());
        }

        public async Task<Product> AddAsync(Product product)
        {
            var entity = product.ToEntity();
            await _context.Set<ProductEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ToProduct();
        }

        public async Task UpdateAsync(Product product)
        {
            var entity = product.ToEntity();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<ProductEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<ProductEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Set<ProductEntity>().AnyAsync(p => p.Id == id);
        }
    }
} 