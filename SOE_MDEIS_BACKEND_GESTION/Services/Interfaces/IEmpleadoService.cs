using SOE_MDEIS_BACKEND_GESTION.DTOs;

namespace SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

public interface IEmpleadoService
{
    Task<IEnumerable<EmpleadoDto>> GetAllAsync();
    Task<EmpleadoDto?> GetByIdAsync(int id);
    Task<EmpleadoDto> CreateAsync(EmpleadoCreateDto dto);
    Task<bool> UpdateAsync(int id, EmpleadoUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
