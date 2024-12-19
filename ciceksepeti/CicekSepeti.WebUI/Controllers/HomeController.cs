using CicekSepeti.Core.Entities;
using CicekSepeti.Service.Abstract;
using CicekSepeti.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CicekSepeti.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Product> _serviceProduct;
        private readonly IService<Slider> _serviceSlider;
        private readonly IService<News> _serviceNews;
        private readonly IService<Contact> _serviceContact;

        public HomeController(IService<Product> serviceProduct, IService<Slider> serviceSlider, IService<News> serviceNews, IService<Contact> serviceContact)
        {
            _serviceProduct = serviceProduct;
            _serviceSlider = serviceSlider;
            _serviceNews = serviceNews;
            _serviceContact = serviceContact;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _serviceSlider.GetAllAsync(),
                News = await _serviceNews.GetAllAsync(),
                Products = await _serviceProduct.GetAllAsync(p => p.IsActive && p.IsHome)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

		[Route("AccessDenied")]

		public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs()
        {
            return View();
        }
        public async Task<IActionResult> ContactUsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   await _serviceContact.AddAsync(contact);
                    var sonuc = await _serviceContact.SaveChangesAsync();
                    if (sonuc > 0)
                    {

                        TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                     <strong>Mesaj�n�z G�nderilmi�tir!</strong>
            <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
           </div>";
                       //await MailHelper.SendMailAsync(contact);
                        return RedirectToAction("ContactUs");

                    }
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata olu�tu!");
                }
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
