using ECommerceAPI.Application.Enums;

namespace ECommerceAPI.Application.CustomAttribute;

public class AuthorizeDefinitionAttribute : Attribute
{
    public string Menu { get; set; }
    public string Definition { get; set; }
    public ActionType ActionType { get; set; }
}