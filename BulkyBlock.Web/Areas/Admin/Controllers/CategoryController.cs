using BulkyBlock.DataAccess;
using BulkyBlock.DataAccess.Repository.IRepository;
using BulkyBlock.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBlock.Web.Areas.Admin.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _db;

    public CategoryController(IUnitOfWork db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> obj = _db.Category.GetAll();
        return View(obj);
    }
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {

        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The Displayorder cannot match");
        }
        if (ModelState.IsValid)
        {
            _db.Category.Add(obj);
            _db.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        else
            return View(obj);
    }
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromDb = _db.Category.GetFirstOrDefault(c => c.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {

        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The Displayorder cannot match");
        }
        if (ModelState.IsValid)
        {
            _db.Category.Update(obj);
            _db.Save();
            TempData["success"] = "Category edited successfully";
            return RedirectToAction("Index");
        }
        else
            return View(obj);
    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Category.GetFirstOrDefault(c => c.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Category.GetFirstOrDefault(c => c.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Category.Remove(obj);
        _db.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }

}



