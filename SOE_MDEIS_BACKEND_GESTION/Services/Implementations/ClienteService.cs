using SOE_MDEIS_BACKEND_GESTION.DTOs;
using SOE_MDEIS_BACKEND_GESTION.Models;
using SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;
using SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Services.Implementations;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var clientes = await _clienteRepository.GetAllAsync();

        return clientes.Select(c => new ClienteDto
        {
            ClienteId = c.ClienteId,
            TipoDocumento = c.TipoDocumento,
            NumeroDocumento = c.NumeroDocumento,
            Nombres = c.Nombres,
            Apellidos = c.Apellidos,
            Email = c.Email,
            Telefono = c.Telefono,
            Direccion = c.Direccion,
            Activo = c.Activo
        });
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var c = await _clienteRepository.GetByIdAsync(id);
        if (c is null) return null;

        return new ClienteDto
        {
            ClienteId = c.ClienteId,
            TipoDocumento = c.TipoDocumento,
            NumeroDocumento = c.NumeroDocumento,
            Nombres = c.Nombres,
            Apellidos = c.Apellidos,
            Email = c.Email,
            Telefono = c.Telefono,
            Direccion = c.Direccion,
            Activo = c.Activo
        };
    }

    public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto)
    {
        var entity = new Cliente
        {
            TipoDocumento = dto.TipoDocumento,
            NumeroDocumento = dto.NumeroDocumento,
            Nombres = dto.Nombres,
            Apellidos = dto.Apellidos,
            Email = dto.Email,
            Telefono = dto.Telefono,
            Direccion = dto.Direccion,
            FechaRegistro = DateTime.UtcNow,
            Activo = true
        };

        await _clienteRepository.AddAsync(entity);
        await _clienteRepository.SaveChangesAsync();

        return new ClienteDto
        {
            ClienteId = entity.ClienteId,
            TipoDocumento = entity.TipoDocumento,
            NumeroDocumento = entity.NumeroDocumento,
            Nombres = entity.Nombres,
            Apellidos = entity.Apellidos,
            Email = entity.Email,
            Telefono = entity.Telefono,
            Direccion = entity.Direccion,
            Activo = entity.Activo
        };
    }

    public async Task<bool> UpdateAsync(int id, ClienteUpdateDto dto)
    {
        var entity = await _clienteRepository.GetByIdAsync(id);
        if (entity is null) return false;

        entity.TipoDocumento = dto.TipoDocumento;
        entity.NumeroDocumento = dto.NumeroDocumento;
        entity.Nombres = dto.Nombres;
        entity.Apellidos = dto.Apellidos;
        entity.Email = dto.Email;
        entity.Telefono = dto.Telefono;
        entity.Direccion = dto.Direccion;
        entity.Activo = dto.Activo;

        _clienteRepository.Update(entity);
        await _clienteRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _clienteRepository.GetByIdAsync(id);
        if (entity is null) return false;

        _clienteRepository.Delete(entity);
        await _clienteRepository.SaveChangesAsync();

        return true;
    }
}
