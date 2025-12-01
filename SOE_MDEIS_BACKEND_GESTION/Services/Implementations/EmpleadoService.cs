using SOE_MDEIS_BACKEND_GESTION.DTOs;
using SOE_MDEIS_BACKEND_GESTION.Models;
using SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;
using SOE_MDEIS_BACKEND_GESTION.Services.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Services.Implementations;

public class EmpleadoService : IEmpleadoService
{
    private readonly IEmpleadoRepository _empleadoRepository;

    public EmpleadoService(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public async Task<IEnumerable<EmpleadoDto>> GetAllAsync()
    {
        var empleados = await _empleadoRepository.GetAllAsync();

        return empleados.Select(e => new EmpleadoDto
        {
            EmpleadoId = e.EmpleadoId,
            TipoDocumento = e.TipoDocumento,
            NumeroDocumento = e.NumeroDocumento,
            Nombres = e.Nombres,
            Apellidos = e.Apellidos,
            Cargo = e.Cargo,
            Email = e.Email,
            Telefono = e.Telefono,
            FechaContratacion = e.FechaContratacion,
            SalarioMensual = e.SalarioMensual,
            Activo = e.Activo
        });
    }

    public async Task<EmpleadoDto?> GetByIdAsync(int id)
    {
        var e = await _empleadoRepository.GetByIdAsync(id);
        if (e is null) return null;

        return new EmpleadoDto
        {
            EmpleadoId = e.EmpleadoId,
            TipoDocumento = e.TipoDocumento,
            NumeroDocumento = e.NumeroDocumento,
            Nombres = e.Nombres,
            Apellidos = e.Apellidos,
            Cargo = e.Cargo,
            Email = e.Email,
            Telefono = e.Telefono,
            FechaContratacion = e.FechaContratacion,
            SalarioMensual = e.SalarioMensual,
            Activo = e.Activo
        };
    }

    public async Task<EmpleadoDto> CreateAsync(EmpleadoCreateDto dto)
    {
        var entity = new Empleado
        {
            TipoDocumento = dto.TipoDocumento,
            NumeroDocumento = dto.NumeroDocumento,
            Nombres = dto.Nombres,
            Apellidos = dto.Apellidos,
            Cargo = dto.Cargo,
            Email = dto.Email,
            Telefono = dto.Telefono,
            FechaContratacion = dto.FechaContratacion,
            SalarioMensual = dto.SalarioMensual,
            Activo = true
        };

        await _empleadoRepository.AddAsync(entity);
        await _empleadoRepository.SaveChangesAsync();

        return new EmpleadoDto
        {
            EmpleadoId = entity.EmpleadoId,
            TipoDocumento = entity.TipoDocumento,
            NumeroDocumento = entity.NumeroDocumento,
            Nombres = entity.Nombres,
            Apellidos = entity.Apellidos,
            Cargo = entity.Cargo,
            Email = entity.Email,
            Telefono = entity.Telefono,
            FechaContratacion = entity.FechaContratacion,
            SalarioMensual = entity.SalarioMensual,
            Activo = entity.Activo
        };
    }

    public async Task<bool> UpdateAsync(int id, EmpleadoUpdateDto dto)
    {
        var entity = await _empleadoRepository.GetByIdAsync(id);
        if (entity is null) return false;

        entity.TipoDocumento = dto.TipoDocumento;
        entity.NumeroDocumento = dto.NumeroDocumento;
        entity.Nombres = dto.Nombres;
        entity.Apellidos = dto.Apellidos;
        entity.Cargo = dto.Cargo;
        entity.Email = dto.Email;
        entity.Telefono = dto.Telefono;
        entity.FechaContratacion = dto.FechaContratacion;
        entity.SalarioMensual = dto.SalarioMensual;
        entity.Activo = dto.Activo;

        _empleadoRepository.Update(entity);
        await _empleadoRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _empleadoRepository.GetByIdAsync(id);
        if (entity is null) return false;

        _empleadoRepository.Delete(entity);
        await _empleadoRepository.SaveChangesAsync();

        return true;
    }
}
