using Barcelona_Store.Data;
using Barcelona_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barcelona_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _context.Categories.ToList();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }
    }
}
