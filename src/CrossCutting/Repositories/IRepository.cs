using CrossCutting.Entities;

namespace CrossCutting.Repositories;

public interface IRepository<T> where T : AggregateRoot
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity, bool saveChanges = true);
    Task<List<T>> CreateRangeAsync(List<T> entities, bool saveChanges = true);
    Task UpdateAsync(T entity, bool saveChanges = true);
    Task UpdateRangeAsync(IEnumerable<T> obj, bool saveChanges = true);
    Task DeleteAsync(T entity, bool saveChanges = true);
    Task DeleteRangeAsync (IEnumerable<T> entity, bool saveChanges = true);
    Task SaveChangesAsync();
}