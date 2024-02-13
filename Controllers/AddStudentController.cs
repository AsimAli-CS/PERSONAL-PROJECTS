using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectStudentSystem.Models;
using System.Diagnostics;
namespace ProjectStudentSystem.Controllers
{
    public class AddStudentController : Controller
    {
        private readonly InterestRepository _interestRepository;
        private readonly ActivityRepository _activityRepository;
        public AddStudentController(InterestRepository interestRepository,ActivityRepository activityRepository)
        {
            _interestRepository = interestRepository ?? throw new ArgumentNullException(nameof(interestRepository));
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));

        }
        [HttpGet]
        public IActionResult AddStudent()
        {
           
            List<Interest> interests = _interestRepository.GetAllInterests();
            ViewBag.Interests=interests;
           

            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudent s,String OtherInterest)
        {
            if (s.Interest == "Other" && OtherInterest!="")
            {
                s.Interest = OtherInterest;
                string Getinterest = s.Interest;
                Interest input = new Interest();
                string interestName = Getinterest;
                input.Interest1 = interestName;
                _interestRepository.AddSignUpInfo(input);
            }
            
            List<Interest> interests = _interestRepository.GetAllInterests();
            ViewBag.Interests = interests;
            bool isMatch = interests.Any(interest => string.Equals(s.Interest, interest.Interest1, StringComparison.OrdinalIgnoreCase));
            String action = "AddStudent";
            _activityRepository.AddActivity(action);


            AddStudentRepository sr = new AddStudentRepository();
            sr.AddSignUpInfo(s);
            ViewBag.ErrorMessage = "Student Add Successfully";
            return View();
        }
        




    }




}