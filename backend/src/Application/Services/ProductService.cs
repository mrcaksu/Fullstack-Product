using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using static Application.DTOs.ProductDtos;

namespace Application.Services
{
    /// <summary>
    /// Ürün servis katmanı.
    /// Repository (veri erişim) katmanı ile Controller arasında iş kurallarını yürütür.
    /// </summary>
    public class ProductService(IProductRepository repo) : IProductService
    {
        /// <summary>
        /// Yeni bir ürün oluşturur ve veritabanına kaydeder.
        /// </summary>
        /// <param name="req">Oluşturulacak ürünün bilgilerini içeren DTO.</param>
        /// <param name="ct">İptal belirteci (isteğe bağlı).</param>
        /// <returns>Oluşturulan ürünün bilgilerini içeren yanıt DTO'su.</returns>
        public async Task<ProductDtos.ProductResponse> CreateAsync(ProductDtos.CreateProductRequest req, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(req.Name)) throw new ArgumentException("Name is required");
            if (req.Price < 0) throw new ArgumentException("Price must be >= 0");

            var entity = new Product { Name = req.Name.Trim(), Description = req.Description, Price = req.Price };
            var created = await repo.AddAsync(entity, ct);
            return new ProductResponse(created.Id, created.Name, created.Description, created.Price, created.CreatedTime);
        }

        /// <summary>
        /// Tüm ürünleri getirir.
        /// </summary>
        /// <param name="ct">İptal belirteci.</param>
        /// <returns>Tüm ürünlerin DTO listesi.</returns>
        public async Task<List<ProductDtos.ProductResponse>> GetAllAsync(CancellationToken ct = default) =>
            (await repo.GetAllAsync(ct))
            .Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.Price, p.CreatedTime))
            .ToList();



        /// <summary>
        /// Verilen kimliğe sahip ürünü getirir.
        /// </summary>
        /// <param name="id">Ürünün benzersiz kimliği (GUID).</param>
        /// <param name="ct">İptal belirteci.</param>
        /// <returns>Ürün bulunursa DTO, aksi takdirde null.</returns>
        public async Task<ProductDtos.ProductResponse?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var p = await repo.GetByIdAsync(id, ct);
            return p is null ? null : new ProductResponse(p.Id, p.Name, p.Description, p.Price, p.CreatedTime);
        }
    }
}