using System.Reflection;
using ECommerceAPI.Application.CustomAttribute;
using ECommerceAPI.Application.Dtos.Configurations;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Services.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ECommerceAPI.Infrastructure.Services.Configurations;

public class ApplicationServices : IApplicationServices
{
    public List<Menu> GetAuthorizeDefinitionEndpoints(Type type)
    {
        Assembly assembly = Assembly.GetAssembly(type);
        var controllers = assembly.GetTypes()
            .Where(a => a.IsAssignableTo(typeof(ControllerBase)));

        List<Menu> menus = new();
        if (controllers != null)
        {
            foreach (Type controller in controllers)
            {
                var actions = controller.GetMethods()
                    .Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)));
                if (actions != null)
                {
                    foreach (MethodInfo action in actions)
                    {
                        var attributes = action.GetCustomAttributes();
                        if (attributes != null)
                        {
                            Menu menu = null;
                            var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                            
                            if (!menus.Any(m => m.Name == authorizeDefinitionAttribute.Menu))
                            {
                                menu = new() { Name = authorizeDefinitionAttribute.Menu };
                                menus.Add(menu);
                            }
                            else
                                menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttribute.Menu);
                            
                            Application.Dtos.Configurations.Action _action = new()
                            {
                                ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
                                Definition = authorizeDefinitionAttribute.Definition
                            };
                            
                            var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                            if (httpAttribute != null)
                                _action.HttpType = httpAttribute.HttpMethods.First();
                            else
                                _action.HttpType = HttpMethods.Get;
                            _action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Definition.Replace(" ", "")}";
                            menu.Actions.Add(_action);
                        }
                    }
                }
            }
        }
        return menus;
    }
}