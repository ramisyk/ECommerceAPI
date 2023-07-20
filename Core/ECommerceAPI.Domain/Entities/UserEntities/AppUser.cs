using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Domain.Entities.UserEntities;

public class AppUser : IdentityUser
{
    public string NameSurname { get; set; }
}