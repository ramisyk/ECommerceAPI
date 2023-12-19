namespace ECommerceAPI.Application.ViewModels.Orders;

public class VM_Single_Order
{
    public string Address { get; set; }
    public object BasketItems { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public Guid Id { get; set; }
    public string OrderCode { get; set; }
}