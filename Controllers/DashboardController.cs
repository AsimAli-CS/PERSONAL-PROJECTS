    using Microsoft.AspNetCore.Mvc;
using ProjectStudentSystem.Models;

namespace ProjectStudentSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AddStudentRepository _repository;
        private readonly ActivityRepository _activityRepository;

        public DashboardController(AddStudentRepository repository, ActivityRepository activityRepository)
        {
            _repository = repository;
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));

        }

        public IActionResult Index()
        {
            int DashBoard = HttpContext.Session.GetInt32("DashBoard") ?? 1;
            if (DashBoard != 1)
            {
                String action = "DashBoard";
                _activityRepository.AddActivity(action);
            }
            DashBoard++;
            HttpContext.Session.SetInt32("DashBoard", DashBoard);
            Response.Cookies.Append("IsAuthenticated", "true");
            var model = new DashboardViewModel
            {
                Top5Interests = _repository.GetTop5Interests(),
                Bottom5Interests = _repository.GetBottom5Interests(),
                DistinctInterestCount = _repository.GetDistinctInterestCount(),
                // Get City distribution data
                CityDistributionLabels = _repository.GetCityDistributionData().Select(data => data.City).ToList(),
                CityDistributionData = _repository.GetCityDistributionData().Select(data => data.Count).ToList(),
                SubmissionChartData = _repository.GetSubmissionChartData(),
                AgeDistributionData = _repository.GetAgeDistributionData(),
                DepartmentDistributionLabels = _repository.GetDepartmentDistributionData().Select(data => data.Department).ToList(),
                DepartmentDistributionData = _repository.GetDepartmentDistributionData().Select(data => data.Count).ToList(),
                DegreeDistributionLabels = _repository.GetDegreeDistributionData().Select(data => data.DegreeTitle).ToList(),
                DegreeDistributionData = _repository.GetDegreeDistributionData().Select(data => data.Count).ToList(),
                GenderDistributionLabels = _repository.GetGenderDistributionData().Select(data => data.Gender).ToList(),
                GenderDistributionData = _repository.GetGenderDistributionData().Select(data => data.Count).ToList(),
                MostActiveHoursLast30Days = _repository.GetMostActiveHoursLast30Days(),
                StudentStatusData = _repository.GetStudentStatusData(),
                LeastActiveHoursLast30Days = _repository.GetLeastActiveHoursLast30Days(),
                DeadHoursLast30Days = _repository.GetDeadHoursLast30Days(),
                Last30DaysActivityData = _activityRepository.GetLast30DaysActivityData(),
                Last24HoursActivityData = _activityRepository.GetLast24HoursActivityData().Select(data => data.Date).ToList(),
                Last24HoursActivityCounts = _activityRepository.GetLast24HoursActivityData().Select(data => data.ActionCount).ToList()
            };



            return View(model);
        }

        public IActionResult Index1()
        {
            Response.Cookies.Append("IsAuthenticated", "true");
            var model = new DashboardViewModel
            {
                Top5Interests = _repository.GetTop5Interests(),
                Bottom5Interests = _repository.GetBottom5Interests(),
                DistinctInterestCount = _repository.GetDistinctInterestCount(),
                // Get City distribution data
                CityDistributionLabels = _repository.GetCityDistributionData().Select(data => data.City).ToList(),
                CityDistributionData = _repository.GetCityDistributionData().Select(data => data.Count).ToList(),
                SubmissionChartData = _repository.GetSubmissionChartData(),
                AgeDistributionData = _repository.GetAgeDistributionData(),
                DepartmentDistributionLabels = _repository.GetDepartmentDistributionData().Select(data => data.Department).ToList(),
                DepartmentDistributionData = _repository.GetDepartmentDistributionData().Select(data => data.Count).ToList(),
                DegreeDistributionLabels = _repository.GetDegreeDistributionData().Select(data => data.DegreeTitle).ToList(),
                DegreeDistributionData = _repository.GetDegreeDistributionData().Select(data => data.Count).ToList(),
                GenderDistributionLabels = _repository.GetGenderDistributionData().Select(data => data.Gender).ToList(),
                GenderDistributionData = _repository.GetGenderDistributionData().Select(data => data.Count).ToList(),
                MostActiveHoursLast30Days = _repository.GetMostActiveHoursLast30Days(),
                StudentStatusData = _repository.GetStudentStatusData(),
                LeastActiveHoursLast30Days = _repository.GetLeastActiveHoursLast30Days(),
                DeadHoursLast30Days = _repository.GetDeadHoursLast30Days(),
                //Last30DaysActivityData = _activityRepository.GetLast30DaysActivityData(),
            };



            return View(model);
        }


    }
}
