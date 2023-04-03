using EcommerceApp.DataAccess;
using EcommerceApp.DataAccess.Repository.IRepository;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAppWeb.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        
        //GET
        public IActionResult Upsert(int? id)
        {
            Product product = new Product();
            if (id==null || id == 0)
            {
                //Create Product
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
        public IActionResult Upsert(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Covertype updated succssfully";
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
            var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSignle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (coverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null) 
            { 
                return NotFound(); 
            }
            _unitOfWork.CoverType.Remove(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Covertype was succssfully deleted";
                return RedirectToAction("Index");
            
        }
    }
}
