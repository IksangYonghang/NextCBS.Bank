using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NextCBS.Bank.Data.Repositories;

public class BaseRepository<T> where T : class
{
    private AppDbContext _context;
    readonly DbSet<T> _dbSet;
    public IQueryable<T> Queryable => _dbSet.AsQueryable();

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> InsertAsync(T entity)
    {

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }
    }

    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<ICollection<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }

    public async Task<T?> GetFirstByConditionAsync(Expression<Func<T, bool>> expression)
    {
        var item = await _dbSet.FirstOrDefaultAsync(expression);
        if (item == null) return null;

        _dbSet.Entry(item).State = EntityState.Detached;
        return item;
    }

    public async Task<T?> GetLastByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.LastOrDefaultAsync(expression);
    }

    public async Task<T?> GetSingleByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.SingleOrDefaultAsync(expression);
    }

    public async Task<T?> GetFirstAsync()
    {
        return await _dbSet.FirstOrDefaultAsync();
    }

    public async Task<T?> GetLastAsync()
    {
        return await _dbSet.LastOrDefaultAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public async Task<int> CountByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.CountAsync(expression);
    }

    public async Task<bool> AnyAsync()
    {
        return await _dbSet.AnyAsync();
    }

    public async Task InsertRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
}