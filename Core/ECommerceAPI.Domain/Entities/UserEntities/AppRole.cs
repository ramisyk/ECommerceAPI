using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Domain.Entities.UserEntities;

public class AppRole : IdentityRole<string>
{
    public ICollection<Endpoint> Endpoints { get; set; }
}