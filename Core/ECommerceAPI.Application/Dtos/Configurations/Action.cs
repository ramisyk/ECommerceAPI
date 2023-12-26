using ECommerceAPI.Application.Enums;

namespace ECommerceAPI.Application.Dtos.Configurations;

public class Action
{
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
    public string Code { get; set; }
}