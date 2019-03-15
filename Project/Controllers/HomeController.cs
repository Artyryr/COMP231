using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure;
//using Project.Infrastructure;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        private IServiceRepository repository;
        private UserManager<GeneralUser> userManager;
        private SignInManager<GeneralUser> signInManager;

        public async Task<GeneralUser> GetCurrentUserAsync()
        {
            GeneralUser user = await userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }
        public HomeController(IServiceRepository repo, UserManager<GeneralUser> userMgr,
                SignInManager<GeneralUser> signInMgr)
        {
            repository = repo;
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
            ////TO DO
            ////LOGIN IS NOT WORKING


            //if (userSearch.loggedInThroughFacebook == true)
            //{

            //}
            //else if (userSearch.loggedInThroughGoogle == true)
            //{
            //    GeneralUser user = userSearch.User;
            //    await signInManager.SignOutAsync();
            //    //await signInManager.SignInAsync(user, false);

            //    var info = signInManager.GetExternalAuthenticationSchemesAsync();
            //    var info2 = signInManager.GetExternalAuthenticationSchemesAsync();
            //    await signInManager.ExternalLoginSignInAsync("Google", "",false);

            //    //    if ((await signInManager.ExternalLoginSignInAsync(
            //    //"Google", userSearch.User.Id, false)).Succeeded)
            //    //    {
            //    return RedirectToAction(userSearch?.ReturnUrl ?? "Index");
            //    //}

            //}
            //else
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

        [HttpGet]
        public async Task<IActionResult> ServiceBookingPage(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                GeneralUser user = await GetCurrentUserAsync();
                return View(new ServiceRequestModel {RequestedService = new RequestedService {ServiceId = id,FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Telephone = user.Telephone, Apartment = user.Apartment, City = user.City, Street = user.Street, Province = user.Province, ZIP = user.ZIP} });
            }
            return View(new ServiceRequestModel { RequestedService = new RequestedService { ServiceId = id }});
        }

        [HttpPost]
        public ActionResult ServiceBookingPage(ServiceRequestModel model)
        {
            if (ModelState.IsValid)
            {
                RequestedService service = model.RequestedService;
                repository.AddRequestedService(service);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult ServicePage(int id)
        {
            Service service = repository.Services.Where(s => s.ServiceId == id).FirstOrDefault();
            ViewBag.Id = id;
            return View(service);
        }

        [HttpPost]
        public ActionResult SearchResult(SearchModel search)
        {
            search.Services = repository.Services.Where(p => p.ServiceName.ToLower().Contains(search.SearchName)).ToList();
            return View(search);
        }

        [HttpGet]
        public ViewResult PlumbingPage() => View(new ServicesViewModel { Services = repository.Services, ServiceTypes = repository.ServiceTypes });

        [HttpGet]
        public ViewResult HeatingPage() => View(new ServicesViewModel { Services = repository.Services, ServiceTypes = repository.ServiceTypes });

        [HttpGet]
        public ViewResult ElectricityPage() => View(new ServicesViewModel { Services = repository.Services, ServiceTypes = repository.ServiceTypes });


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrationPage(RegistrationModel newUser)
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