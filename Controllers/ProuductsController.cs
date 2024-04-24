using Microsoft.AspNetCore.Mvc;
using ProductWebsite.Models;
using SQLitePCL;

namespace ProductWebsite.Controllers
{
    public class ProductController : Controller
    {
        private ProductCatalogContext _catalogContext;
        public ProductController(ProductCatalogContext context)
        {

            _catalogContext = context;
        }
        public IActionResult Index(string SearchField = "")
        {
            var product = _catalogContext.Products.AsQueryable();
            if (SearchField != "")
            {
                product = product.Where(a => a.Name.StartsWith(SearchField));
            }

            return View(product.ToList());
        }

        public IActionResult Details(int id)
        {
            var product = _catalogContext.Products.Find(id);

            return View(product);
        }

        public IActionResult AddProductForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProductForm(AddProductForm form)
        {
            if (ModelState.IsValid) 
            {
                
                var newProduct = new Product()
                {
                    Name = form.ProductName,
                    ImageUrl = form.imageURL,
                    Price = form.price
                };
                _catalogContext.Products.Add(newProduct);            
                _catalogContext.SaveChanges();
                return RedirectToAction("Details", new {  Id = newProduct.Id });   
            }
            return View(form);
        }

        public IActionResult EditForm( int id)
        {
            var product = _catalogContext.Products.Find(id);
            var form = new EditProductForm () { imageURL = product.ImageUrl, price = product.Price, ProductName= product.Name };

            return View(form);
        }
        [HttpPost]
        public IActionResult EditForm(int id, EditProductForm form)
        {
            if (ModelState.IsValid)
            {
                var product = _catalogContext.Products.Find(id);
                product.Name= form.ProductName;
                product.ImageUrl= form.imageURL;
                product.Price = form.price;
                
                _catalogContext.SaveChanges();
                return RedirectToAction("Details", new { Id = product.Id });
            }
            return View(form);
        }
        public IActionResult delete(int id)
        {
            var product = _catalogContext.Products.Find(id);
            _catalogContext.Products.Remove(product);
            _catalogContext.SaveChanges();
        
            return RedirectToAction("Index");
        }
    }
  
}
