using SOE_MDEIS_BACKEND_GESTION.Models;

namespace SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;

public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<Producto?> GetByCodigoAsync(string codigo);
}