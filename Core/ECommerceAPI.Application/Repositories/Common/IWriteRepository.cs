using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Application.Repositories.Common;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> AddRangeAsync(List<T> models);

    bool Remove(T model);
    bool RemoveRange(List<T> models);
    Task<bool> RemoveAsync(Guid id);

    bool Update(T model);

    Task<int> SaveAsync();
}