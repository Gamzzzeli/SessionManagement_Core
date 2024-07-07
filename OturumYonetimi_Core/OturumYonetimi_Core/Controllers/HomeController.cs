using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OturumYonetimi_Core.Data;
using OturumYonetimi_Core.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace OturumYonetimi_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)   // Yapýcý metod
        {
            _context = context;
        }

        public IActionResult Giris()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Giris(Kullanicilar kullanici,string ReturnUrl)
        {
            var login = _context.Kullanicilars.Where(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre).FirstOrDefault();
            if (login != null)
            {
                var talep = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,kullanici.KullaniciAdi.ToString())
                };
                ClaimsIdentity kimlik = new ClaimsIdentity(talep, "Login");
                ClaimsPrincipal kural = new ClaimsPrincipal(kimlik);
                HttpContext.SignInAsync(kural);
                if(!String.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
