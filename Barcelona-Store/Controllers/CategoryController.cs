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
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "DisplayOrder ile Name aynı olmaması lazim");
            }
            if (ModelState.IsValid) {
            _context.Categories.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
            }
            return View(obj);
        }
    }
}
