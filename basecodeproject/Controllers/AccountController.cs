using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecodeproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace basecodeproject.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
 

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Login(string email, string password)
        {

            var hasUser = await _userManager.FindByEmailAsync(email);
            if (hasUser == null)  return View();
          

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser,password,true,false);

            //if (signInResult.RequiresTwoFactor)
            //{
            //OTP veya sms ile giriş için kullanılır.
            //}

            if (!signInResult.Succeeded)
            {
                return View();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }



    }
}

