using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Entities.FileEntities;

namespace ECommerceAPI.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }

    public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    public ICollection<Order> Orders { get; set; }
}