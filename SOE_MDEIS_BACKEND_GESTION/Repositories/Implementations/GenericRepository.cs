using Microsoft.EntityFrameworkCore;
using SOE_MDEIS_BACKEND_GESTION.Data;
using SOE_MDEIS_BACKEND_GESTION.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SOE_MDEIS_BACKEND_GESTION.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id)
        => await _dbSet.FindAsync(id);

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

    public virtual async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public virtual void Update(T entity)
        => _dbSet.Update(entity);

    public virtual void Delete(T entity)
        => _dbSet.Remove(entity);

    public virtual async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
