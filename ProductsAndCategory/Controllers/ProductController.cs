using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategory.Models;

namespace ProductsAndCategory.Controllers
{
    public class ProductController : Controller
    {
        ContextDemo cntx;
        public ProductController(ContextDemo cntx)
        {
            this.cntx = cntx;
        }
       
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10; 
            var products = this.cntx.Products
                .Include(p => p.Category) 
                .OrderBy(p => p.ProductId) 
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalRecords = this.cntx.Products.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.CurrentPage = page;

            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryId", "CategoryName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Product rec)
        {
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryId", "CategoryName");
            if (ModelState.IsValid)
            {
                this.cntx.Products.Add(rec);
                this.cntx.SaveChanges();

            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cntx.Products.Find(id);
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryId", "CategoryName",rec.Category);

            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Product rec)
        {
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryId", "CategoryName",rec.Category);

            if (ModelState.IsValid)
            {
                this.cntx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cntx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Delete(Int64 id)
        {

            var rec = this.cntx.Products.Find(id);
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryId", "CategoryName",rec.Category);

            return View(rec);
        }
        [HttpPost]
        public IActionResult Delete(Product rec)
        {
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryId", "CategoryName");

            this.cntx.Products.Remove(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
