using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Domain.Entities.UserEntities;

namespace ECommerceAPI.Application.Abstractions.TokenServices;

public interface ITokenHandler
{
    Token CreateAccessToken(int second, AppUser user);
    string CreateRefreshToken(int second);
}