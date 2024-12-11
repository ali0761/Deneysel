using Microsoft.AspNetCore.Mvc;

namespace CicekSepeti.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
