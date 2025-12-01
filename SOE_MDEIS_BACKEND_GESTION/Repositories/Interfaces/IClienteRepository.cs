using SOE_MDEIS_BACKEND_GESTION.Models;

namespace SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;

public interface IClienteRepository : IGenericRepository<Cliente>
{
    Task<Cliente?> GetByNumeroDocumentoAsync(string numeroDocumento);
}
