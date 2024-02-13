using Microsoft.AspNetCore.Mvc;
using ProjectStudentSystem.Models;
using System.Diagnostics;

namespace ProjectStudentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ActivityRepository _activityRepository;

        public HomeController(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));

        }
        public IActionResult Index()
        {
            int Homepage = HttpContext.Session.GetInt32("Homepage") ?? 1;
            if (Homepage != 1)
            {
                String action = "Home";
                _activityRepository.AddActivity(action);
            }
            Homepage++;
            HttpContext.Session.SetInt32("Homepage", Homepage);
            return View();
        }
    }
}