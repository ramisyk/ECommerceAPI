namespace ECommerceAPI.Application.Abstractions.Hubs;

public interface IOrderHubService
{
    Task OrderCreatedMessageAsync(string message);
}