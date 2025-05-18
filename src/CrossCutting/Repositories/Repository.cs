using CrossCutting.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.Repositories;

public class Repository<T>(DbContext context) : IRepository<T>
    where T : AggregateRoot
{
    public TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext
        => (context as TDbContext)!;

    protected readonly DbSet<T> DbSet = context.Set<T>();

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity, bool saveChanges = true)
    {
        await DbSet.AddAsync(entity);

        if (saveChanges)
            await context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<T>> CreateRangeAsync(List<T> entities, bool saveChanges = true)
    {
        await DbSet.AddRangeAsync(entities);
        
        if(saveChanges)
            await context.SaveChangesAsync();
        
        return entities;
    }

    public async Task UpdateAsync(T entity, bool saveChanges = true)
    {
        DbSet.Update(entity);
        
        if(saveChanges)
            await context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        DbSet.UpdateRange(entities);
        
        if(saveChanges)
            await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity, bool saveChanges = true)
    {
        DbSet.Remove(entity);
        
        if(saveChanges)
            await context.SaveChangesAsync();
    }
    
    public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        DbSet.RemoveRange(entities);
        
        if(saveChanges)
            await context.SaveChangesAsync();
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}