using CrossCutting.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.Repositories;

public class Repository<TUser> : IRepository<TUser> 
    where TUser : AggregateRoot
{
    private readonly DbContext _context;
    protected readonly DbSet<TUser> DbSet;

    protected Repository(DbContext context)
    {
        _context = context;
        DbSet = context.Set<TUser>();
    }

    public async Task<TUser> CreateAsync(TUser entity, bool saveChanges = true)
    {
        await DbSet.AddAsync(entity);

        if (saveChanges)
            await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<TUser>> CreateRangeAsync(List<TUser> entities, bool saveChanges = true)
    {
        await DbSet.AddRangeAsync(entities);
        
        if(saveChanges)
            await _context.SaveChangesAsync();
        
        return entities;
    }

    public async Task UpdateAsync(TUser entity, bool saveChanges = true)
    {
        DbSet.Update(entity);
        
        if(saveChanges)
            await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<TUser> entities, bool saveChanges = true)
    {
        DbSet.UpdateRange(entities);
        
        if(saveChanges)
            await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TUser entity, bool saveChanges = true)
    {
        DbSet.Remove(entity);
        
        if(saveChanges)
            await _context.SaveChangesAsync();
    }
    
    public async Task DeleteRangeAsync(IEnumerable<TUser> entities, bool saveChanges = true)
    {
        DbSet.RemoveRange(entities);
        
        if(saveChanges)
            await _context.SaveChangesAsync();
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}