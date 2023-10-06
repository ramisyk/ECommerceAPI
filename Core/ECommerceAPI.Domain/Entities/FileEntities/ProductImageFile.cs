using System.Reflection.Metadata.Ecma335;

namespace ECommerceAPI.Domain.Entities.FileEntities;

public class ProductImageFile : BaseFile
{
    //todo add migration 
    public bool Showcase { get; set; }
    public ICollection<Product> Products { get; set; }
}