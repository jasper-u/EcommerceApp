using EcommerceAppWeb.Data;
using EcommerceAppWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MainDbContext _db;

        public CategoryController(MainDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
    }
}
