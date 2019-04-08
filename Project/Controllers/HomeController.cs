using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure;
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
                Payment payment = repository.Payments.Where(p => p.UserId == user.Id).FirstOrDefault();
                if (payment != null)
                {
                    return View(new ServiceRequestModel { RequestedService = new RequestedService { ServiceId = id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Telephone = user.Telephone, Apartment = user.Apartment, City = user.City, Street = user.Street, Province = user.Province, ZIP = user.ZIP }, Payment = payment });
                }
                else { return View(new ServiceRequestModel { RequestedService = new RequestedService { ServiceId = id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Telephone = user.Telephone, Apartment = user.Apartment, City = user.City, Street = user.Street, Province = user.Province, ZIP = user.ZIP } }); }
            }
            return View(new ServiceRequestModel { RequestedService = new RequestedService { ServiceId = id } });
        }

        [HttpPost]
        public async Task<ActionResult> ServiceBookingPage(ServiceRequestModel model)
        {
            if (ModelState.IsValid)
            {
                GeneralUser user = await GetCurrentUserAsync();
                Service service = repository.Services.Where(p => p.ServiceId == model.RequestedService.ServiceId).FirstOrDefault();
                RequestedService requestedService = model.RequestedService;
                Payment payment = model.Payment;

                requestedService.AddPayment(payment);
                requestedService.TotalPrice = requestedService.NumberOfHours * service.PricePerHour - (requestedService.NumberOfHours * service.PricePerHour * user.Discount);

                repository.AddPayment(payment);
                repository.AddRequestedService(requestedService);

                model.Discount = user.Discount;
                model.RequestedService = requestedService;

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
            List<Review> reviews = (from rev in repository.Reviews
                                    where rev.ServiceId == id
                                    orderby rev.Date descending
                                    select rev).ToList();
            service.AddReviews(reviews);
            ViewBag.Id = id;
            return View(service);
        }

        [HttpPost]
        public async Task<ActionResult> ServicePage(Review review)
        {
            Service service = repository.Services.Where(s => s.ServiceId == review.ServiceId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                GeneralUser user = await GetCurrentUserAsync();
                review.UserName = user.FirstName + " " + user.LastName;
                review.UserId = user.Id;
                review.Date = DateTime.Now;
                repository.AddReview(review);
            }
            List<Review> reviews = (from rev in repository.Reviews
                                    where rev.ServiceId == review.ServiceId
                                    orderby rev.Date descending
                                    select rev).ToList();

            service.AddReviews(reviews);
            return View(service);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UpdateProfile()
        {
            GeneralUser user = await GetCurrentUserAsync();
            return View(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UpdateProfile(GeneralUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GeneralUser currentUser = await GetCurrentUserAsync();
                    currentUser.Apartment = user.Apartment;
                    currentUser.City = user.City;
                    currentUser.FirstName = user.FirstName;
                    currentUser.LastName = user.LastName;
                    currentUser.PhoneNumber = user.PhoneNumber;
                    currentUser.Province = user.Province;
                    currentUser.Street = user.Street;
                    currentUser.Telephone = user.Telephone;
                    currentUser.ZIP = user.ZIP;
                    await userManager.UpdateAsync(currentUser);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View(user);
                }
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult SearchResult(SearchModel search)
        {
            if (search.Filter == null || search.Filter == "0")
            {
                search.Services = repository.Services.Where(p => p.ServiceName.ToLower().Contains(search.SearchName)).ToList();
                return View(search);
            }
            else
            {
                search.Services = repository.Services.Where(p => p.ServiceName.ToLower().Contains(search.SearchName) && p.ServiceTypeId == Convert.ToInt32(search.Filter)).ToList();
                return View(search);
            }
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
                        newUser.User.Discount = 5;
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