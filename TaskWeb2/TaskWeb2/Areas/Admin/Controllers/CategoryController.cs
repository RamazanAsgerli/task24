using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskWeb2.DAL;
using TaskWeb2.Models;

namespace TaskWeb2.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {

        AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.Include(x=>x.Products).ToList();
            return View(categories);
        }

        public IActionResult Delete(int? id)
        {
            var category=_context.Categories.FirstOrDefault(x=>x.Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
