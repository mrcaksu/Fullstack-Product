using Domain.Entities;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Ürünler için veri erişim sözleşmesi (CRUD).
    /// Uygulama katmanı, kalıcı katmana bu arayüz üzerinden erişir.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>Yeni ürünü ekler ve kaydeder.</summary>
        /// <param name="product">Eklenecek ürün varlığı.</param>
        /// <param name="ct">İptal belirteci.</param>
        /// <returns>Oluşturulan ürün (kimliğiyle birlikte).</returns>
        Task<Product> AddAsync(Product product, CancellationToken ct = default);

        /// <summary>Tüm ürünleri getirir (sadece okuma).</summary>
        /// <param name="ct">İptal belirteci.</param>
        /// <returns>Ürün listesi.</returns>
        Task<List<Product>> GetAllAsync(CancellationToken ct = default);

        /// <summary>Kimliğe göre tek ürünü getirir (sadece okuma).</summary>
        /// <param name="id">Ürün kimliği.</param>
        /// <param name="ct">İptal belirteci.</param>
        /// <returns>Varlık ya da <c>null</c>.</returns>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}