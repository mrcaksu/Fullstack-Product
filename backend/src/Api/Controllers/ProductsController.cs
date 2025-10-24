using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Application.DTOs.ProductDtos;

namespace Api.Controllers
{
    /// <summary>
    /// Product CRUD endpoints.
    /// Ürün oluşturma, listeleme, tekil getirme, güncelleme ve silme işlemlerini sağlar.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService svc) : ControllerBase
    {
        /// <summary>
        /// Yeni bir ürün oluşturur.
        /// </summary>
        /// <param name="req">Ürün oluşturma isteği (ad description ve fiyat).</param>
        /// <response code="400">Geçersiz istek (ör. boş ad, negatif fiyat).</response>
        [HttpPost("add-product")]
        public async Task<ActionResult<ProductResponse>> Create([FromBody] CreateProductRequest req, CancellationToken ct)
        {
            var created = await svc.CreateAsync(req, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Tüm ürünleri listeler.
        /// </summary>
        /// <remarks>
        /// Örnek istek: GET /api/get-products
        /// </remarks>
        /// <response code="200">Ürün listesi başarıyla döndü.</response>
        [HttpGet("Get-All-Products")]
        public async Task<ActionResult<List<ProductResponse>>> GetAll(CancellationToken ct) =>
        await svc.GetAllAsync(ct);


        /// <summary>
        /// Belirtilen <c>id</c> değerine sahip ürünü getirir.
        /// </summary>
        /// <param name="id">Ürünün benzersiz kimliği (GUID).</param>
        /// <response code="200">Ürün bulundu ve döndürüldü.</response>
        /// <response code="404">Verilen <c>id</c> ile ürün bulunamadı.</response>
        [HttpGet("Get-Product/{id:guid}")]
        public async Task<ActionResult<ProductResponse>> GetById(Guid id, CancellationToken ct)
        {
            var p = await svc.GetByIdAsync(id, ct);
            return p is null ? NotFound() : Ok(p);
        }
    }
}