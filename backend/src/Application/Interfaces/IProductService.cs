using static Application.DTOs.ProductDtos;

namespace Application.Interfaces
{
    /// <summary>
    /// Ürün yönetimi (CRUD) işlemleri için servis sözleşmesini tanımlar.
    /// Controller katmanı ile Repository katmanı arasında bir köprü görevi görür.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Yeni bir ürün oluşturur.
        /// </summary>
        /// <param name="req">Oluşturulacak ürünün bilgilerini içeren DTO.</param>
        /// <param name="ct">İptal belirteci (isteğe bağlı).</param>
        /// <returns>Oluşturulan ürünün bilgilerini içeren yanıt DTO'su.</returns>
        Task<ProductResponse> CreateAsync(CreateProductRequest request, CancellationToken ct = default);

        /// <summary>
        /// Tüm ürünleri getirir.
        /// </summary>
        /// <param name="ct">İptal belirteci.</param>
        /// <returns>Ürün listesi.</returns>
        Task<List<ProductResponse>> GetAllAsync(CancellationToken ct = default);


        /// <summary>
        /// Verilen ID’ye göre tek bir ürünü getirir.
        /// </summary>
        /// <param name="id">Ürünün benzersiz kimliği (GUID).</param>
        /// <param name="ct">İptal belirteci.</param>
        /// <returns>Ürün bulunursa DTO, aksi takdirde null.</returns>
        Task<ProductResponse?> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}