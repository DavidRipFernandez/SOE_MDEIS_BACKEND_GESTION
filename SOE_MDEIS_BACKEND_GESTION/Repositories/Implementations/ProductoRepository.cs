using Microsoft.EntityFrameworkCore;
using SOE_MDEIS_BACKEND_GESTION.Data;
using SOE_MDEIS_BACKEND_GESTION.Models;
using SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;

namespace SOE_MDEIS_BACKEND_GESTION.Repositories.Implementations;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    public ProductoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Producto?> GetByCodigoAsync(string codigo)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Codigo == codigo);
    }
}
