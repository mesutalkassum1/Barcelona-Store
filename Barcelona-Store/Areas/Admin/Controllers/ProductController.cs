using Barcelona_Store.Data;
using BarcelonaStore.DataAccess.Repository.IRepository;
using BarcelonaStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Barcelona_Store.Controllers;
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<MaterialType> objMaterialTypeList = _unitOfWork.MaterialType.GetAll();
        return View(objMaterialTypeList);
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        Product product = new();
        IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            u=> new SelectListItem
            {
                Text=u.Name,
                Value = u.Id.ToString()
            });
        IEnumerable<SelectListItem> MaterialTypeList = _unitOfWork.Category.GetAll().Select(
            u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
        if (id == null || id == 0)
        {
            //Create Product
            ViewBag.CategoryList = CategoryList;
            return View(product);
        }
        else
        {
            //Update Product
        }


        return View(product);
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(MaterialType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.MaterialType.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "MaterialType Updated Successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var MaterialTypeFromDbFirst = _unitOfWork.MaterialType.GetFirstOrDefault(u => u.Id == id);

        if (MaterialTypeFromDbFirst == null)
        {
            return NotFound();
        }
        return View(MaterialTypeFromDbFirst);
    }
    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.MaterialType.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.MaterialType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "MaterialType Deleted Successfully";
        return RedirectToAction("Index");
    }
}
