using SOE_MDEIS_BACKEND_GESTION.DTOs;

namespace SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(int id);
    Task<ClienteDto> CreateAsync(ClienteCreateDto dto);
    Task<bool> UpdateAsync(int id, ClienteUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
