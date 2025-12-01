using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOE_MDEIS_BACKEND_GESTION.DTOs;
using SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
        {
            var productos = await _productoService.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDto>> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto is null) return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Create([FromBody] ProductoCreateDto dto)
        {
            var created = await _productoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ProductoId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoUpdateDto dto)
        {
            var updated = await _productoService.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
