using SOE_MDEIS_BACKEND_GESTION.DTOs;

namespace SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

public interface IProductoService
{
    Task<IEnumerable<ProductoDto>> GetAllAsync();
    Task<ProductoDto?> GetByIdAsync(int id);
    Task<ProductoDto> CreateAsync(ProductoCreateDto dto);
    Task<bool> UpdateAsync(int id, ProductoUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
