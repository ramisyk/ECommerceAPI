using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers;

public class FilesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}