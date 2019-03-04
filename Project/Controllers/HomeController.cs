using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Project.Infrastructure;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<GeneralUser> userManager;
        private SignInManager<GeneralUser> signInManager;

        public HomeController(UserManager<GeneralUser> userMgr,
                SignInManager<GeneralUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [HttpGet]
        public ViewResult Index() => View();

        public ViewResult LoginPage(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginPage(LoginModel userSearch)
        {
            if (ModelState.IsValid)
            {
                GeneralUser user =
                    await userManager.FindByEmailAsync(userSearch.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                            userSearch.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction(userSearch?.ReturnUrl ?? "Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(userSearch);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public ViewResult RegistrationPage()
        {
            return View();
        }

        public ViewResult PlumbingPage()
        {
            return View();
        }
        public ViewResult HeatingPage()
        {
            return View();
        }
        public ViewResult ElectricityPage()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrationPage(LoginModel newUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (newUser.Password == newUser.ConfirmationPassword)
                    {
                        newUser.User.UserName = newUser.Email;
                        newUser.User.Email = newUser.Email;
                        GeneralUser user = await userManager.FindByEmailAsync(newUser.Email);
                        if (user == null)
                        {
                            IdentityResult result = await userManager.CreateAsync(newUser.User, newUser.Password);

                            if (result.Succeeded)
                            {
                                return RedirectToAction(nameof(HomeController.LoginPage), "Home");
                            }
                            else
                            {
                                return View();
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "This email is already used in the database!");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Passwords do not match");
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}