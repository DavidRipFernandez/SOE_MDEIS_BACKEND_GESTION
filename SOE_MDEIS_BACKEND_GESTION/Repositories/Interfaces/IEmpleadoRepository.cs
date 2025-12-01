using SOE_MDEIS_BACKEND_GESTION.Models;

namespace SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;

public interface IEmpleadoRepository : IGenericRepository<Empleado>
{
    Task<Empleado?> GetByNumeroDocumentoAsync(string numeroDocumento);
}