using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// EF Core tabanlı ürün veri erişim katmanı.
    /// <see cref="AppDbContext"/> üzerinden CRUD işlemlerini gerçekleştirir.
    /// </summary>
    public class ProductRepository(AppDbContext db) : IProductRepository
    {
        /// <inheritdoc />
        public async Task<Product> AddAsync(Product product, CancellationToken ct = default)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync(ct);
            return product;
        }

        /// <inheritdoc />
        public Task<List<Product>> GetAllAsync(CancellationToken ct = default)
        {
            return db.Products.AsNoTracking().OrderByDescending(p => p.CreatedTime).ToListAsync(ct);
        }


        /// <inheritdoc />
        public Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);
        }
    }
}