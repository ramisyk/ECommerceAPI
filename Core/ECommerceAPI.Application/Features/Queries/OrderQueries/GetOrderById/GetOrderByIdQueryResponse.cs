namespace ECommerceAPI.Application.Features.Queries.OrderQueries.GetOrderById;

public class GetOrderByIdQueryResponse
{
    public string Address { get; set; }
    public object BasketItems { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public Guid Id { get; set; }
    public string OrderCode { get; set; }
    public bool Completed { get; set; }
    
}