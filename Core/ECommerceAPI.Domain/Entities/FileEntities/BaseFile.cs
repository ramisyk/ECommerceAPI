using System.ComponentModel.DataAnnotations.Schema;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities.FileEntities;

public class BaseFile : BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }       
    public string Storage { get; set; }
    // Don't need to update date for files 
    [NotMapped]
    public override DateTime UpdatedDate { get; set; }
}