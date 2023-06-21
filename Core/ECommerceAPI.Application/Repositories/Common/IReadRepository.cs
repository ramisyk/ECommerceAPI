using System.Linq.Expressions;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Application.Repositories.Common;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
    Task<T> GetByIdAsync(Guid id);
}