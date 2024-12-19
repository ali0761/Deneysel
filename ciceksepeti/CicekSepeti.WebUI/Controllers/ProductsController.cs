using CicekSepeti.Core.Entities;
using CicekSepeti.Service.Abstract;
using CicekSepeti.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IService<Product> _serviceProduct;

        public ProductsController(IService<Product> serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        public async Task<IActionResult> Index(string q ="")
        {
            var databaseContext = _serviceProduct.GetAllAsync(p=>p.IsActive && p.Name.Contains(q) || p.Description.Contains(q));
            return View(await databaseContext);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _serviceProduct.GetQueryable()
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDetailViewModel() { Product = product,
                RelatedProducts = _serviceProduct.GetQueryable().Where(p => p.IsActive && p.CategoryID == product.CategoryID && p.ID != product.ID)
            };
            return View(model);
        }
    }
}
