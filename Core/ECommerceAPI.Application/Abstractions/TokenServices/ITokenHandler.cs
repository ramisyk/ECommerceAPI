using ECommerceAPI.Application.Dtos;

namespace ECommerceAPI.Application.Abstractions.TokenServices;

public interface ITokenHandler
{
    Token CreateAccessToken(int second);

}