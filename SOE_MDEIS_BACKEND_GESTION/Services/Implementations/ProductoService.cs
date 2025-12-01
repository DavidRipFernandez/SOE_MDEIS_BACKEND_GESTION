using SOE_MDEIS_BACKEND_GESTION.DTOs;
using SOE_MDEIS_BACKEND_GESTION.Models;
using SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;
using SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Services.Implementations;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<IEnumerable<ProductoDto>> GetAllAsync()
    {
        var productos = await _productoRepository.GetAllAsync();

        return productos.Select(p => new ProductoDto
        {
            ProductoId = p.ProductoId,
            Codigo = p.Codigo,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Categoria = p.Categoria,
            PrecioUnitario = p.PrecioUnitario,
            StockActual = p.StockActual,
            Activo = p.Activo
        });
    }

    public async Task<ProductoDto?> GetByIdAsync(int id)
    {
        var p = await _productoRepository.GetByIdAsync(id);
        if (p is null) return null;

        return new ProductoDto
        {
            ProductoId = p.ProductoId,
            Codigo = p.Codigo,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Categoria = p.Categoria,
            PrecioUnitario = p.PrecioUnitario,
            StockActual = p.StockActual,
            Activo = p.Activo
        };
    }

    public async Task<ProductoDto> CreateAsync(ProductoCreateDto dto)
    {
        var entity = new Producto
        {
            Codigo = dto.Codigo,
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Categoria = dto.Categoria,
            PrecioUnitario = dto.PrecioUnitario,
            StockActual = dto.StockActual,
            FechaRegistro = DateTime.UtcNow,
            Activo = true
        };

        await _productoRepository.AddAsync(entity);
        await _productoRepository.SaveChangesAsync();

        return new ProductoDto
        {
            ProductoId = entity.ProductoId,
            Codigo = entity.Codigo,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            Categoria = entity.Categoria,
            PrecioUnitario = entity.PrecioUnitario,
            StockActual = entity.StockActual,
            Activo = entity.Activo
        };
    }

    public async Task<bool> UpdateAsync(int id, ProductoUpdateDto dto)
    {
        var entity = await _productoRepository.GetByIdAsync(id);
        if (entity is null) return false;

        entity.Nombre = dto.Nombre;
        entity.Descripcion = dto.Descripcion;
        entity.Categoria = dto.Categoria;
        entity.PrecioUnitario = dto.PrecioUnitario;
        entity.StockActual = dto.StockActual;
        entity.Activo = dto.Activo;

        _productoRepository.Update(entity);
        await _productoRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _productoRepository.GetByIdAsync(id);
        if (entity is null) return false;

        _productoRepository.Delete(entity);
        await _productoRepository.SaveChangesAsync();

        return true;
    }
}
