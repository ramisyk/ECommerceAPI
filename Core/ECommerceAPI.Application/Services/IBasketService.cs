using ECommerceAPI.Application.ViewModels.Basket;
using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Services;

public interface IBasketService
{
    public Task<List<BasketItem>> GetBasketItemsAsync();
    public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);
    public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
    public Task RemoveBasketItemAsync(Guid basketItemId);
    public Basket? GetUserActiveBasket { get; }

}