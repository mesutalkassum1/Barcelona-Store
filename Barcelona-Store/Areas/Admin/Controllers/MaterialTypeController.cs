using BarcelonaStore.DataAccess;
using BarcelonaStore.DataAccess.Repository.IRepository;
using BarcelonaStore.Models;
using BarcelonaStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Barcelona_Store.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class MaterialTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public MaterialTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<MaterialType> objMaterialTypeList = _unitOfWork.MaterialType.GetAll();
        return View(objMaterialTypeList);
    }

    //GET
    public IActionResult Create()
    {
        
        return View();
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MaterialType obj)
    {
        if (ModelState.IsValid) {
        _unitOfWork.MaterialType.Add(obj);
        _unitOfWork.Save();
        TempData["success"] = "MaterialType Created Successfully";
        return RedirectToAction("Index"); 
        }
        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0)
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(MaterialType obj)
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
