using Microsoft.EntityFrameworkCore;
using SOE_MDEIS_BACKEND_GESTION.Data;
using SOE_MDEIS_BACKEND_GESTION.Models;
using SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Repositories.Implementations;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Empleado?> GetByNumeroDocumentoAsync(string numeroDocumento)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(e => e.NumeroDocumento == numeroDocumento);
    }
}
