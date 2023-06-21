using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Application.Repositories.Common;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}