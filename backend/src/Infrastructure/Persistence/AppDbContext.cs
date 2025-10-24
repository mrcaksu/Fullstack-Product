using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Uygulamanın EF Core bağlamı.
    /// Varlık kümeleri ve tablo eşlemeleri burada tanımlanır.
    /// </summary>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        /// <summary>Ürünler tablosu için DbSet.</summary>
        public DbSet<Product> Products => Set<Product>();

        /// <summary>
        /// Varlık-tip eşlemelerini ve kısıtları yapılandırır.
        /// </summary>
        /// <param name="modelBuilder">Model oluşturucu.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Name).IsRequired().HasMaxLength(200);
                b.Property(e => e.Price).HasColumnType("decimal(18,2)");
                b.Property(e => e.Description).HasMaxLength(1000);
                b.Property(e => e.CreatedTime).IsRequired();
            });
        }
    }
}