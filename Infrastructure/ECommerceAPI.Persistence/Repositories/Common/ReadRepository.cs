using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using ECommerceAPI.Application.Repositories.Common;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Repositories.Common;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly  ECommerceAPIDbContext _context;

    public ReadRepository(ECommerceAPIDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    public IQueryable<T> GetAll(bool tracking = false)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;

    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = false)
    {
        var query = Table.Where(filter);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = false)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query.AsNoTracking();
        return await query.FirstOrDefaultAsync(filter);
    }

    public async Task<T> GetByIdAsync(Guid id, bool tracking = false)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query.AsNoTracking();
        return await query.FirstOrDefaultAsync(entity => entity.Id == id);
    }
}