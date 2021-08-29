using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNet5.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}