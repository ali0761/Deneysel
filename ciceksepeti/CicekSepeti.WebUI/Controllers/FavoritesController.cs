using CicekSepeti.Core.Entities;
using CicekSepeti.Service.Abstract;
using CicekSepeti.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace CicekSepeti.WebUI.Controllers
{
	public class FavoritesController : Controller
	{
        private readonly IService<Product> _service;

        public FavoritesController(IService<Product> service)
        {
            _service = service;
        }
        public IActionResult Index()
		{
			var favoriler = GetFavorites();
			return View(favoriler);
		}
		private List<Product> GetFavorites()
		{
			return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? [];
		}
		public IActionResult Add(int ProductId)
		{
			var favoriler = GetFavorites();
			var product = _service.Find(ProductId);
			if (product != null && !favoriler.Any(p => p.ID == ProductId))
			{
				favoriler.Add(product);
				HttpContext.Session.SetJson("GetFavorites", favoriler);
			}
			return RedirectToAction("Index");
		}
		public IActionResult Remove(int ProductId)
		{
			var favoriler = GetFavorites();
			var product = _service.Find(ProductId);
			if (product != null && favoriler.Any(p => p.ID == ProductId))
			{
				favoriler.RemoveAll(i=>i.ID == product.ID);
				HttpContext.Session.SetJson("GetFavorites", favoriler);
			}
			return RedirectToAction("Index");
		}
	}
}
