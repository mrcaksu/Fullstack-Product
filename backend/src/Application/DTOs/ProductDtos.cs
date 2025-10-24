namespace Application.DTOs
{
    public class ProductDtos
    {
        /// <summary>
        /// Ürün oluşturma isteği DTO'su.
        /// </summary>
        public record CreateProductRequest(string Name, string Description, decimal Price);
        /// <summary>
        /// API yanıtında döndürülen ürün modeli.
        /// </summary>
        public record ProductResponse(Guid Id, string Name, string Description, decimal Price, DateTime CreatedTime);
    }
}