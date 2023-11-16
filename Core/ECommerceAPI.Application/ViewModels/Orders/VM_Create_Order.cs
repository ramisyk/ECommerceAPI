namespace ECommerceAPI.Application.ViewModels.Orders;

public class VM_Create_Order
{
    public Guid BasketId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
}