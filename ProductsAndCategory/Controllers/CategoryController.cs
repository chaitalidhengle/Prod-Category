using Microsoft.AspNetCore.Mvc;
using ProductsAndCategory.Models;

namespace ProductsAndCategory.Controllers
{
    public class CategoryController : Controller
    {
        ContextDemo cntx;
        public CategoryController(ContextDemo cntx)
        {
            this.cntx = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cntx.Categories.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category rec)
        {
            if (ModelState.IsValid)
            {
                this.cntx.Categories.Add(rec);
                this.cntx.SaveChanges();
                
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec=this.cntx.Categories.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Category rec)
        {
            if (ModelState.IsValid)
            {
                this.cntx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cntx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Delete (Int64 id)
        {
            var rec = this.cntx.Categories.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Delete(Category rec)
        {
            this.cntx.Categories.Remove(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
