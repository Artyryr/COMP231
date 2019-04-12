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
    /// <summary>
    /// Controller class that handles transactions between pages
    /// </summary>
    public class HomeController : Controller
    {
        private IServiceRepository repository;
        private UserManager<GeneralUser> userManager;
        private SignInManager<GeneralUser> signInManager;

        /// <summary>
        /// Method for getting information about logged in user
        /// </summary>
        /// <returns>
        /// Instance of current user
        /// </returns>
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

        /// <summary>
        /// Method that shows index page.
        /// </summary>
        [HttpGet]
        public ViewResult Index() => View();

        /// <summary>
        /// Method that shows Login Page
        /// </summary>
        public ViewResult LoginPage(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Method that used for login functionaluty
        /// </summary>
        /// <param name="userSearch">Login information of user</param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginPage(LoginModel userSearch)
        {

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

        /// <summary>
        /// Method that handles logout feature
        /// </summary>
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        /// <summary>
        /// Shows Registration Page
        /// </summary>
        public ViewResult RegistrationPage()
        {
            return View();
        }

        /// <summary>
        /// Shows Page for booking a specific service
        /// </summary>
        /// <param name="id">Id of a service</param>
        [HttpGet]
        public async Task<IActionResult> ServiceBookingPage(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                GeneralUser user = await GetCurrentUserAsync();
                Payment payment = repository.Payments.Where(p => p.UserId == user.Id).LastOrDefault();
                if (payment != null)
                {
                    return View(new ServiceRequestModel { RequestedService = new RequestedService { ServiceId = id, UserId = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Telephone = user.Telephone, Apartment = user.Apartment, City = user.City, Street = user.Street, Province = user.Province, ZIP = user.ZIP }, Payment = payment });
                }
                else { return View(new ServiceRequestModel { RequestedService = new RequestedService { ServiceId = id, UserId = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Telephone = user.Telephone, Apartment = user.Apartment, City = user.City, Street = user.Street, Province = user.Province, ZIP = user.ZIP } }); }
            }
            return View(new ServiceRequestModel { RequestedService = new RequestedService { ServiceId = id } });
        }

        /// <summary>
        /// Get the request for booking of a specific service
        /// </summary>
        /// <param name="model">Service model</param>
        [HttpPost]
        public async Task<ActionResult> ServiceBookingPage(ServiceRequestModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        GeneralUser user = await GetCurrentUserAsync();
                        Service service = repository.Services.Where(p => p.ServiceId == model.RequestedService.ServiceId).FirstOrDefault();
                        RequestedService requestedService = model.RequestedService;
                        Payment payment = model.Payment;
                        payment.UserId = user.Id;

                        requestedService.AddPayment(payment);
                        requestedService.UserId = user.Id;
                        requestedService.TotalPrice = requestedService.NumberOfHours * service.PricePerHour - (requestedService.NumberOfHours * service.PricePerHour * user.Discount / 100);

                        repository.AddPayment(payment);
                        repository.AddRequestedService(requestedService);

                        model.Discount = user.Discount;
                        model.RequestedService = requestedService;
                        model.Service = service;
                        model.User = user;

                        return RedirectToAction("BookingConfirmationPage", new BookingConfirmationModel { Discount = model.Discount, ServiceId = model.Service.ServiceId, RequestedServiceId = model.RequestedService.RequestedServiceId, PaymentId = model.Payment.PaymentId });
                    }
                    else
                    {
                        Service service = repository.Services.Where(p => p.ServiceId == model.RequestedService.ServiceId).FirstOrDefault();
                        RequestedService requestedService = model.RequestedService;
                        Payment payment = model.Payment;

                        requestedService.AddPayment(payment);
                        requestedService.TotalPrice = requestedService.NumberOfHours * service.PricePerHour;

                        repository.AddRequestedService(requestedService);
                        model.RequestedService = requestedService;
                        model.Service = service;

                        return RedirectToAction("BookingConfirmationPage", new BookingConfirmationModel { ServiceId = model.Service.ServiceId, RequestedServiceId = model.RequestedService.RequestedServiceId, PaymentId = model.Payment.PaymentId });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        /// <summary>
        /// Shows the page of booking confirmation
        /// </summary>
        [HttpGet]
        public ActionResult BookingConfirmationPage(BookingConfirmationModel model)
        {
            Service service = repository.Services.Where(p => p.ServiceId == model.ServiceId).FirstOrDefault();
            RequestedService requested = repository.RequestedServices.Where(p => p.RequestedServiceId == model.RequestedServiceId).FirstOrDefault();
            Payment payment = repository.Payments.Where(p => p.PaymentId == model.PaymentId).LastOrDefault();
            ServiceRequestModel serviceRequest = new ServiceRequestModel();

            if (User.Identity.IsAuthenticated)
            {
                serviceRequest = new ServiceRequestModel { Service = service, RequestedService = requested, Payment = payment, Discount = model.Discount };
            }
            else
            {
                serviceRequest = new ServiceRequestModel { Service = service, RequestedService = requested, Payment = payment };
            }

            return View(serviceRequest);
        }

        /// <summary>
        /// Shows a page of a specific service
        /// </summary>
        /// <param name="id">Id of a specific service</param>
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

        /// <summary>
        /// Handles addition of a review for a specific service
        /// </summary>
        /// <param name="review">Review</param>
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

        /// <summary>
        /// Show a page of a personal profile
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> ProfilePage()
        {
            GeneralUser user = await GetCurrentUserAsync();
            List<RequestedService> requestedServices = (from service in repository.RequestedServices
                                                        where service.UserId == user.Id
                                                        orderby service.Date ascending
                                                        select service).ToList();
            List<ServiceRequestSummary> services = new List<ServiceRequestSummary>();
            Payment payment = repository.Payments.Where(p => p.UserId == user.Id).LastOrDefault();

            foreach (var item in requestedServices)
            {
                Service ser = (Service)(from service in repository.Services
                                        where service.ServiceId == item.ServiceId
                                        select service).FirstOrDefault();
                ServiceRequestSummary summary = new ServiceRequestSummary { ServiceName = ser.ServiceName, PricePerHour = ser.PricePerHour, Date = item.Date, NumberOfHours = item.NumberOfHours, TotalPrice = item.TotalPrice };
                services.Add(summary);
            }
            ProfileModel model = new ProfileModel { RequestedServices = services, User = user, UserPayment = payment };
            return View(model);
        }

        /// <summary>
        /// Shows a form for profile update
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UpdateProfile()
        {
            GeneralUser user = await GetCurrentUserAsync();
            return View(user);
        }

        /// <summary>
        /// Handles update of user profile
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns></returns>
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

        /// <summary>
        /// Shows a page with search results
        /// </summary>
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

        /// <summary>
        /// SHows a page with all plumbing services
        /// </summary>
        [HttpGet]
        public ViewResult PlumbingPage() => View(new ServicesViewModel { Services = repository.Services, ServiceTypes = repository.ServiceTypes });

        /// <summary>
        /// Shows a page with all Heating Services
        /// </summary>
        [HttpGet]
        public ViewResult HeatingPage() => View(new ServicesViewModel { Services = repository.Services, ServiceTypes = repository.ServiceTypes });

        /// <summary>
        /// Shows a page with all Electrical Services
        /// </summary>
        [HttpGet]
        public ViewResult ElectricityPage() => View(new ServicesViewModel { Services = repository.Services, ServiceTypes = repository.ServiceTypes });

        /// <summary>
        /// Handles registraion of a new user
        /// </summary>
        /// <param name="newUser">User information</param>
        /// <returns></returns>
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