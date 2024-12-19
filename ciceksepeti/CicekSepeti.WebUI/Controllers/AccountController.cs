using CicekSepeti.Core.Entities;
using CicekSepeti.Service.Abstract;
using CicekSepeti.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CicekSepeti.WebUI.Controllers
{
	public class AccountController : Controller
	{
		//private readonly DatabaseContext _context;

		//public AccountController(DatabaseContext context)
		//{
		//    _context = context;
		//}
		private readonly IService<AppUser> _service;

        public AccountController(IService<AppUser> service)
        {
            _service = service;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync()
		{
			AppUser user = await _service.GetAsync(x=>x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
			if (user is null) {
                return NotFound();

            }
			var model = new UserEditViewModel() { 
			
			
			Email = user.Email,
			ID=user.ID,
			Name = user.Name,
			Password = user.Password,
			Phone = user.Phone,
			Surname = user.Surname,
			};
            return View(model);
		}

        [HttpPost, Authorize]
        public async Task<IActionResult> IndexAsync(UserEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
                    AppUser user = await _service.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
                    if (user is not null) 
					{
                        user.Surname = model.Surname;
						user.Phone = model.Phone;
						user.Name = model.Name;
						user.Password = model.Password;
						user.Email = model.Email;
                        _service.Update(user);
                       var sonuc = _service.SaveChanges();

                        if (sonuc > 0)
                        {

                            TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                     <strong>Bilgileriniz güncellenmiştir!</strong>
            <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
           </div>";
                            //await MailHelper.SendMailAsync(contact);
                            return RedirectToAction("Index");

                        }
                    }


                }
                catch (Exception)
				{
					ModelState.AddModelError("", "Hata oluştu!");
				}
			}
			return View(model);
		}
		
		public IActionResult SignIn()
		{
			return View();
		}

		public HttpContext GetHttpContext()
		{
			return HttpContext;
		}

		[HttpPost]
		public async Task<IActionResult> SignInAsync(LoginViewModel loginViewModel, HttpContext httpContext)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var account = await _service.GetAsync(x=>x.Email == loginViewModel.Email & x.Password == loginViewModel.Password & x.IsActive);
					if (account == null)
					{
						ModelState.AddModelError("", " Giriş Başarısız!");

					}
					else
					{
						var claims = new List<Claim>()
						{
							 new(ClaimTypes.Name, account.Name),
							new(ClaimTypes.Role, account.IsAdmin ? "Admin" : "Customer"),
							new(ClaimTypes.Email, account.Email),
							new("UserID", account.ID.ToString()),
							new("UserGuid", account.UserGuid.ToString()),
						};
						var userIdentity = new ClaimsIdentity(claims,"Login");
						ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
						await HttpContext.SignInAsync(userPrincipal);
						return RedirectToAction("Index", "Home");
					}
				}
				catch (Exception hata)
				{
					//loglar ekleyebilirim
					ModelState.AddModelError("", "Hata Oluştu!");
				}
			}

			return View(loginViewModel);
		}
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUpAsync(AppUser appUser)
		{
            appUser.IsAdmin = false;
            appUser.IsActive = true;
            if (ModelState.IsValid)
            {
                await _service.AddAsync(appUser);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(IndexAsync));
            }
            return View(appUser);
        }
		public async Task<IActionResult> SignOutAsync()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("SignIn");
		}
	}
}
