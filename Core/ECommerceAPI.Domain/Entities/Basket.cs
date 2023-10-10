using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Entities.UserEntities;

namespace ECommerceAPI.Domain.Entities;

public class Basket : BaseEntity
{
    public Guid UserId { get; set; }
    // public Guid OrderId { get; set; }
    
    public AppUser User { get; set; }
    public Order Order { get; set; }
    
    public ICollection<BasketItem> BasketItems { get; set; }
}