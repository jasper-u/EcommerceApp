using EcommerceApp.DataAccess;
using EcommerceApp.DataAccess.Repository.IRepository;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
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
                ModelState.AddModelError("CustomError", "Name and Display Order can not be the same.");
            }
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["Success"] = "New category is created succssfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = _db.GetFirstOrDefault(u=>u.Id==id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Display Order can not be the same.");
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["Success"] = "Category updated succssfully";
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
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.GetFirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSignle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if (obj == null) 
            { 
                return NotFound(); 
            }
                _db.Remove(obj);
                _db.Save();
                TempData["Success"] = "Category was succssfully deleted";
                return RedirectToAction("Index");
            
        }
    }
}
