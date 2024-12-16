using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductsMvc.Infarstucture.Data;
using ProductsMvc.Models;

namespace ProductsMvc.Controllers
{
    public class ProductController : Controller
    {
        private ProductMvcContext _context;

        public ProductController(ProductMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.Products.ToList());
        }


        public IActionResult Details(int id)
        {

            Product? p = _context.Products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Product? p = _context.Products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product newP)
        {
            _context.Products.Update(newP);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}