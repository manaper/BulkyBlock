using BulkyBlock.DataAccess;
using BulkyBlock.DataAccess.Repository.IRepository;
using BulkyBlock.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBlock.Web.Areas.Admin.Controllers;

public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _db;

    public CoverTypeController(IUnitOfWork db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<CoverType> obj = _db.CoverType.GetAll();
        return View(obj);
    }
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {

        
        if (ModelState.IsValid)
        {
            _db.CoverType.Add(obj);
            _db.Save();
            TempData["success"] = "CoverType created successfully";
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
        var CoverTypeFromDb = _db.CoverType.GetFirstOrDefault(c => c.Id == id);
        if (CoverTypeFromDb == null)
        {
            return NotFound();
        }
        return View(CoverTypeFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {

       
        if (ModelState.IsValid)
        {
            _db.CoverType.Update(obj);
            _db.Save();
            TempData["success"] = "CoverType edited successfully";
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
        var CoverTypeFromDb = _db.CoverType.GetFirstOrDefault(c => c.Id == id);
        if (CoverTypeFromDb == null)
        {
            return NotFound();
        }
        return View(CoverTypeFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.CoverType.GetFirstOrDefault(c => c.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.CoverType.Remove(obj);
        _db.Save();
        TempData["success"] = "CoverType deleted successfully";
        return RedirectToAction("Index");
    }

}



