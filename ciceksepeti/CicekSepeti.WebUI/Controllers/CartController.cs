using CicekSepeti.Core.Entities;
using CicekSepeti.Service.Abstract;
using CicekSepeti.Service.Concrate;
using CicekSepeti.WebUI.ExtensionMethods;
using CicekSepeti.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CicekSepeti.WebUI.Controllers
{
    public class CartController : Controller
    {
		private readonly IService<Product> _serviceProduct;

		public CartController(IService<Product> serviceProduct)
		{
			_serviceProduct = serviceProduct;
		}
		public IActionResult Index()
        {
			var cart = GetCart();
			var model = new CartViewModel()
			{
				CartLines=cart.CartLines,
				TotalPrice=cart.TotalPrice()
			};
			return View(model);
        }
		public IActionResult Add(int ProductId,int quantity=1)
		{
			var product = _serviceProduct.Find(ProductId);
			if (product != null)
			{
				var cart = GetCart();
				cart.AddProduct(product, quantity);
				HttpContext.Session.SetJson("Cart", cart);
				return Redirect(Request.Headers["Referer"].ToString());
			}
			return RedirectToAction("Index");
		}


		public IActionResult Update(int ProductId,int quantity=1)
		{
			var product = _serviceProduct.Find(ProductId);
			if (product != null)
			{
				var cart = GetCart();
				cart.UpdateProduct(product, quantity);
				HttpContext.Session.SetJson("Cart", cart);
			}
			return RedirectToAction("Index");

		}
		public IActionResult Remove(int ProductId)
		{
			var product = _serviceProduct.Find(ProductId);
			if (product != null)
			{
				var cart = GetCart();
				cart.RemoveProduct(product);
				HttpContext.Session.SetJson("Cart", cart);
			}
			return RedirectToAction("Index");

		}

		[Authorize]
		public IActionResult Checkout()
		{
			var cart = GetCart();
			var model = new CheckoutViewModel()
			{
				CartProducts = cart.CartLines,
				TotalPrice = cart.TotalPrice()
			};
			return View(model);
		}

		private CartService GetCart()
		{
			return HttpContext.Session.GetJson<CartService>("Cart") ?? new CartService();	
		}

    }
}
