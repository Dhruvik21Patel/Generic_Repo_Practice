using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Sample_Project.Models;
using System.Diagnostics;

namespace Sample_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _toastNotification;
        public HomeController(ILogger<HomeController> logger,INotyfService toastNotification)
        {
            _logger = logger;
            _toastNotification = toastNotification;
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