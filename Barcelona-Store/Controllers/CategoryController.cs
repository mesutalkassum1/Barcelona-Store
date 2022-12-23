using Microsoft.AspNetCore.Mvc;

namespace Barcelona_Store.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
