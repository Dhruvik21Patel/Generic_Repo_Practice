using Microsoft.AspNetCore.Mvc;

namespace Sample_Project.Controllers
{
    public class SkillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
