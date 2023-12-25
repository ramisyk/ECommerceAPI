namespace ECommerceAPI.Application.ViewModels.Orders;

public class VM_Completed_Order
{
    public string OrderCode { get; set; }
    public DateTime OrderDate { get; set; }
    public string Username { get; set; }
    public string EMail { get; set; }
}