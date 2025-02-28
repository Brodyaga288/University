using Domain.Models;
using Infrastructure.Repository.Intarface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implemetation;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
{
    private readonly ApplicationContext _context;
    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return _context.Set<TEntity>().ToList();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _context.Set<TEntity>().Remove(await _context.Set<TEntity>().FindAsync(id));
        await _context.SaveChangesAsync();
        return true;
    }
}