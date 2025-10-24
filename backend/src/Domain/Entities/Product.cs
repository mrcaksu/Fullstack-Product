namespace Domain.Entities
{
    /// <summary>
    /// Ürün varlığı (domain entity).
    /// Uygulamanın temel iş kavramını temsil eder.
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}