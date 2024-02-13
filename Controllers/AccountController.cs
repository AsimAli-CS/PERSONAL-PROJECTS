using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectStudentSystem.Models;
using System.Diagnostics;

namespace ProjectStudentSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ActivityRepository _activityRepository;

        public AccountController(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));

        }
        public IActionResult Logout()
        {
            String action = "Logout";
            _activityRepository.AddActivity(action);
            Response.Cookies.Delete("IsAuthenticated");
            return RedirectToAction("login","login");
        }
    }
}