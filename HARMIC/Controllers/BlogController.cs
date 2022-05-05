using Microsoft.AspNetCore.Mvc;

namespace HARMIC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
