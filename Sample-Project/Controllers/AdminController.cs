using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample_Project.entities.ViewModels;
using Sample_Project.Services.Interface;

namespace Sample_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminServices _adminService;
        private readonly INotyfService _toastNotification;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminController(IAdminServices adminService, INotyfService toastNotification, IHttpContextAccessor httpContextAccessor)
        {
            _adminService = adminService;
            _toastNotification = toastNotification;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult AdminPage()
        {
            return View();
        }
        public IActionResult ListSkills(int? page, string? search, string sorting)
        {
            // Get the current filter settings from the session (if they exist)
            var storedPage = HttpContext.Session.GetInt32("Page");
            var storedSearch = HttpContext.Session.GetString("Search");
            var storedSorting = HttpContext.Session.GetString("Sorting");

            // If the filter settings are not provided, use the stored settings from the session
            if(page == 1 && storedPage!=null)
                page = storedPage;
            search ??= storedSearch;
            sorting ??= storedSorting;
            // Set default values if the filters are null or empty
            if (!string.IsNullOrEmpty(search))
            {
                HttpContext.Session.SetString("Search", search); // Replace "defaultSearchValue" with your desired default value
            }

            if (!string.IsNullOrEmpty(sorting))
            {
                HttpContext.Session.SetString("Sorting", sorting); // Replace "defaultSortingValue" with your desired default value
            }

            // Store the updated filter settings in the session
            HttpContext.Session.SetInt32("Page", page.Value);
            var skillData = _adminService.pagedListSkill(page, search, sorting);
            if(skillData==null)
            {
                HttpContext.Session.SetInt32("Page", (page.Value-1));
                skillData = _adminService.pagedListSkill(page, search, sorting);
            }
            return PartialView("_ListOfSkill", skillData);
        }
        [HttpPost]
        public IActionResult AddorUpdateSkill(AddUpdateSkillViewModel skillViewModel)
        {
            string error = "";
            if (skillViewModel.id == null || skillViewModel.id == 0)
            {

                var nameExists = _adminService.Any(x => x.SkillName == skillViewModel.skillName);
                if (nameExists)
                {
                    _toastNotification.Warning("Skill Name already exists!!", 3);
                    return Ok("Skill Name already exists!!");
                }
            }
            else
            {
                var nameExists = _adminService.Any(x => x.SkillName == skillViewModel.skillName && x.Id != skillViewModel.id && x.DeletedDate == null);
                if (nameExists)
                {
                    _toastNotification.Warning("Skill Name already exists!!", 3);
                    return Ok("Skill Name already exists!!");
                }
            }
            if (skillViewModel.id == 0)
            {
                _adminService.addSkill(skillViewModel.status, skillViewModel.skillName);
                _toastNotification.Success("Skill Added Successfully..", 3);
                return Ok("add");
            }
            else
            {
                _adminService.updateSkill(skillViewModel.id, skillViewModel.skillName, skillViewModel.status);
                _toastNotification.Success("Skill Updated Successfully..", 3);
            }
            return Ok("update");
        }
        
        [HttpPost]
        public IActionResult DeleteSkill(int skillId)
        {
            _adminService.deleteSkill(skillId);
            _toastNotification.Warning("Skill Deleted Successfully..",3);
            return Ok();

        }
    }
}
