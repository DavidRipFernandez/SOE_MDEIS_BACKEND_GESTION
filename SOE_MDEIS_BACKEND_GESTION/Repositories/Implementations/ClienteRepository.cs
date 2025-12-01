using Microsoft.EntityFrameworkCore;
using SOE_MDEIS_BACKEND_GESTION.Data;
using SOE_MDEIS_BACKEND_GESTION.Models;
using SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Repositories.Implementations;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Cliente?> GetByNumeroDocumentoAsync(string numeroDocumento)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(c => c.NumeroDocumento == numeroDocumento);
    }
}
