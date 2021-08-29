using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNet5.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}