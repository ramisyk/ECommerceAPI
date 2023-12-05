namespace ECommerceAPI.Application.Features.Queries.OrderQueries.GetAllOrders;

public class GetAllOrdersQueryResponse
{
    public int TotalOrderCount { get; set; }
    public object Orders { get; set; }
}