using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Sample_Project.entities.Auth;
using Sample_Project.entities.Helper;
using Sample_Project.entities.ViewModels;
using Sample_Project.Services.Interface;

namespace Sample_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly INotyfService _toastNotification;
        private readonly IAccountServices _accountServices;
        public AccountController(IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration, INotyfService toastNotification, IAccountServices accountServices)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _toastNotification = toastNotification;
            _accountServices = accountServices;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ValidateLogin(LoginViewModel model)
        {
            if (ModelState.IsValid) { 
                var user = _accountServices.validateLogin(model);
                if (user == null)
                {
                    _toastNotification.Error("User Not Found..", 5);
                    return RedirectToAction("Login");
                }
                else
                {
                    if (user.Status == false)
                    {
                        _toastNotification.Error("You Are No Longer Active User..", 5);
                        return RedirectToAction("Login");
                    }
                    var sessionDetailsViewModel = _accountServices.getUserRoleAndSetToSession(user);
                    var jwtSetting = _configuration.GetSection(nameof(JwtSetting)).Get<JwtSetting>();
                    var token = JwtTokenHelper.GenerateToken(jwtSetting, sessionDetailsViewModel);
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        _toastNotification.Error("Something Went Wrong Please try again..??", 5);
                        return View("Login");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Token", token);
                        HttpContext.Session.SetString("Avtar", user?.Avatar ?? "");
                        HttpContext.Session.SetString("Name", user.FirstName + " " + user.LastName);
                        HttpContext.Session.SetString("Role", user.UserRole.ToString());
                        var message = "";
                        if (HttpContext.Session.GetString("Role") == "Admin")
                            message = "Admin";
                        else
                            message = "User";
                        
                        _toastNotification.Success($"{message} login sucessfully..", 5);
                    }
                }
                return RedirectToAction("AdminPage", "Admin");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
        public IActionResult LogOut()
        {
            var message = "";
            if (HttpContext.Session.GetString("Role") == "Admin")
                message = "Admin";
            else
                message = "User";
            HttpContext.Session.Clear();
            _toastNotification.Success($"{message} Logout Sucessfully...", 3);
            return RedirectToAction("Login", "Account");
        }
    }
}
