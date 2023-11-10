using ECommerceAPI.Application.Repositories.BasketItemRepositories;
using ECommerceAPI.Application.Repositories.BasketRepositories;
using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.ViewModels.Basket;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Services;

public class BasketService : IBasketService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AppUser> _userManager;
    private readonly IOrderReadRepository _orderReadRepository;
    private readonly IBasketReadRepository _basketReadRepository;
    private readonly IBasketWriteRepository _basketWriteRepository;
    private readonly IBasketItemReadRepository _basketItemReadRepository;
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;

    public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager,
        IOrderReadRepository orderReadRepository, IBasketWriteRepository basketWriteRepository,
        IBasketItemWriteRepository basketItemWriteRepository, IBasketItemReadRepository basketItemReadRepository,
        IBasketReadRepository basketReadRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _orderReadRepository = orderReadRepository;
        _basketWriteRepository = basketWriteRepository;
        _basketItemWriteRepository = basketItemWriteRepository;
        _basketItemReadRepository = basketItemReadRepository;
        _basketReadRepository = basketReadRepository;
    }

    private async Task<Basket?> ContextUser()
    {
        var username = _httpContextAccessor.HttpContext?.User.Identity?.Name;
        // it should return the basket if it is not included in any order
        if (!string.IsNullOrEmpty(username))
        {
            AppUser? user = await _userManager.Users
                .Include(u => u.Baskets)
                .FirstOrDefaultAsync(u => u.UserName == username);

            var _basket = from basket in user.Baskets
                join order in _orderReadRepository.Table
                    on basket.Id equals order.Id into BasketOrders
                from order in BasketOrders.DefaultIfEmpty()
                select new
                {
                    Basket = basket,
                    Order = order
                };

            Basket? targetBasket = null;
            if (_basket.Any(b => b.Order is null))
                targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
            else
            {
                targetBasket = new();
                user.Baskets.Add(targetBasket);
            }

            await _basketWriteRepository.SaveAsync();
            return targetBasket;
        }

        // todo throw user not found error
        throw new Exception();
    }

    public async Task<List<BasketItem>> GetBasketItemsAsync()
    {
        Basket? basket = await ContextUser();

        Basket? result = await _basketReadRepository.Table
            .Include(b => b.BasketItems)
            .ThenInclude(bi => bi.Product)
            .FirstOrDefaultAsync(b => b.Id == basket.Id);

        return result.BasketItems
            .ToList();
    }

    public async Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
    {
        Basket? basket = await ContextUser();
        if (basket != null)
        {
            BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi =>
                bi.BasketId == basket.Id && bi.ProductId == basketItem.ProductId);
            if (_basketItem != null)
                _basketItem.Quantity++;
            else
            {
                await _basketItemWriteRepository.AddAsync(new()
                {
                    BasketId = basket.Id,
                    ProductId = basketItem.ProductId,
                    Quantity = basketItem.Quantity
                });
            }
                
            await _basketItemWriteRepository.SaveAsync();
        }
        // todo throw error
    }

    public async Task UpdateQuantityAsync(VM_Update_BasketItem basketItem)
    {
        BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);
        if (_basketItem != null)
        {
            _basketItem.Quantity = basketItem.Quantity;
            await _basketItemWriteRepository.SaveAsync();
        }
    }

    public async Task RemoveBasketItemAsync(Guid basketItemId)
    {
        BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
        if (basketItem != null)
        {
            _basketItemWriteRepository.Remove(basketItem);
            await _basketItemWriteRepository.SaveAsync();
        }
    }
}