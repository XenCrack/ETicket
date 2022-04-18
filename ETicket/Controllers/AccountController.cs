using ETicket.Data;
using ETicket.Data.ViewModels;
using ETicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public AccountController(ApplicationDbContext applicationDbContext, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }

                TempData["Error"] = "Şifrenizi kontrol ediniz.";

                return View(model);
            }

            TempData["Error"] = "Belirtilen e-posta adresi veya şifre hatalı.";

            return View(model);
        }

        public IActionResult Register() => View(new RegisterViewModel());
       
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Belirtilen e-posta adresi sistemde kayıtlıdır.";
                return View(model);
            }

            var newUser = new ApplicationUser()
            {
                Name = model.FullName.Split(' ')[0],
                Surname = model.FullName.Split(' ')[1],
                Email = model.EmailAddress,
                BirthDate = model.BirthDate,
                UserName = "useruser"
            };

            var result = await _userManager.CreateAsync(newUser, model.ConfirmPassword);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "User");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }
    }
}
