using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectStudentSystem.Models;
using System.Diagnostics;

namespace ProjectStudentSystem.Controllers
{
    public class loginController : Controller
    {
        private readonly ActivityRepository _activityRepository;

        public loginController(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));

        }

        [HttpGet]
        public IActionResult login()
        {
            Response.Cookies.Append("IsAuthenticated", "false");
            return View();
        }
        [HttpPost]
        public IActionResult login(User s)
        {
            Response.Cookies.Append("IsAuthenticated", "false");
            loginRepository l2 = new loginRepository();
            string uname = l2.CheckLogIn(s);

            if (uname != null && s.Username.Contains("Admin", StringComparison.OrdinalIgnoreCase))
            {
                int loginPage = HttpContext.Session.GetInt32("loginPage") ?? 1;
                if (loginPage != 1)
                {
                    String action = "Login";
                    _activityRepository.AddActivity(action);
                }
                loginPage++;
                HttpContext.Session.SetInt32("loginPage", loginPage);
                Response.Cookies.Append("IsAuthenticated", "true");

                ViewBag.AuthenticationStatus = true;
                return RedirectToAction("Index", "Admin");
            }
            else if(uname != null && !s.Username.Contains("Admin", StringComparison.OrdinalIgnoreCase))
            {
                int loginPage = HttpContext.Session.GetInt32("loginPage") ?? 1;
                if (loginPage != 1)
                {
                    String action = "Login";
                    _activityRepository.AddActivity(action);
                }
                loginPage++;
                HttpContext.Session.SetInt32("loginPage", loginPage);
                Response.Cookies.Append("IsAuthenticated", "true");
                return RedirectToAction("Index1", "Dashboard");
            }
            else
            {
                Response.Cookies.Delete("IsAuthenticated");
                ViewBag.AuthenticationStatus = false;
                ViewBag.ErrorMessage = "Invalid username or password. Please try again.";
                return View(); // Return the login view here
            }
        }


    }
}