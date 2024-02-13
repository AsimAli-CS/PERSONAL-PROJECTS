using Microsoft.EntityFrameworkCore;

namespace ProjectStudentSystem.Models
{
    public class AddStudentRepository
    {
        private readonly AddStudentContext _context;

        private readonly ActivityContext _Activitycontext;
        public AddStudentRepository()
        {

        }
        public AddStudentRepository(AddStudentContext context, ActivityContext activityContext)
        {
            _context = context;
            _Activitycontext = activityContext;
        }
        public void AddSignUpInfo(AddStudent s)
        {
            s.CreateDate = DateTime.Now;
            AddStudentContext sx = new AddStudentContext();
            sx.AddStudents.Add(s);
            sx.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.AddStudents.Find(id);
            if (student != null)
            {
                _context.AddStudents.Remove(student);
                _context.SaveChanges();
            }
        }

        public List<AddStudent> GetAllStudents()
        {
            return _context.AddStudents.ToList();
        }

        public AddStudent GetStudentById(int id)
        {
            return _context.AddStudents.Find(id);
        }


        public void UpdateStudent(AddStudent student)
        {
            student.CreateDate = DateTime.Now;
            _context.AddStudents.Update(student);
            _context.SaveChanges();
        }


        public List<AddStudent> SortStudents(List<AddStudent> students, string sortColumn, string sortOrder)
        {
            switch (sortColumn)
            {
                case "FullName":
                    return sortOrder == "asc" ? students.OrderBy(s => s.FullName).ToList() : students.OrderByDescending(s => s.FullName).ToList();
                case "RollNo":
                    return sortOrder == "asc" ? students.OrderBy(s => s.RollNo).ToList() : students.OrderByDescending(s => s.RollNo).ToList();
                case "Email":
                    return sortOrder == "asc" ? students.OrderBy(s => s.Email).ToList() : students.OrderByDescending(s => s.Email).ToList();
                case "Gender":
                    return sortOrder == "asc" ? students.OrderBy(s => s.Gender).ToList() : students.OrderByDescending(s => s.Gender).ToList();
                case "DateOfBirth":
                    return sortOrder == "asc" ? students.OrderBy(s => s.DateOfBirth).ToList() : students.OrderByDescending(s => s.DateOfBirth).ToList();
                case "City":
                    return sortOrder == "asc" ? students.OrderBy(s => s.City).ToList() : students.OrderByDescending(s => s.City).ToList();
                case "Interest":
                    return sortOrder == "asc" ? students.OrderBy(s => s.Interest).ToList() : students.OrderByDescending(s => s.Interest).ToList();
                case "Department":
                    return sortOrder == "asc" ? students.OrderBy(s => s.Department).ToList() : students.OrderByDescending(s => s.Department).ToList();
                case "DegreeTitle":
                    return sortOrder == "asc" ? students.OrderBy(s => s.DegreeTitle).ToList() : students.OrderByDescending(s => s.DegreeTitle).ToList();
                case "Subject":
                    return sortOrder == "asc" ? students.OrderBy(s => s.Subject).ToList() : students.OrderByDescending(s => s.Subject).ToList();
                case "StartDate":
                    return sortOrder == "asc" ? students.OrderBy(s => s.StartDate).ToList() : students.OrderByDescending(s => s.StartDate).ToList();
                case "EndDate":
                    return sortOrder == "asc" ? students.OrderBy(s => s.EndDate).ToList() : students.OrderByDescending(s => s.EndDate).ToList();

                default:

                    return students;
            }
        }

        public List<string> GetTop5Interests()
        {

            var topInterests = _context.AddStudents
                .GroupBy(s => s.Interest)
                .OrderByDescending(group => group.Count())
                .Take(5)
                .Select(group => group.Key)
                .ToList();

            return topInterests;
        }

        public List<string> GetBottom5Interests()
        {
            var bottomInterests = _context.AddStudents
                .GroupBy(s => s.Interest)
                .OrderBy(group => group.Count())
                .Take(5)
                .Select(group => group.Key)
                .ToList();

            return bottomInterests;
        }

        public int GetDistinctInterestCount()
        {
            var distinctInterestCount = _context.AddStudents
                .Select(s => s.Interest)
                .Distinct()
                .Count();

            return distinctInterestCount;
        }

        public List<CityDistributionData> GetCityDistributionData()
        {
            var cityDistribution = _context.AddStudents
                .GroupBy(s => s.City)
                .Select(group => new CityDistributionData
                {
                    City = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return cityDistribution;
        }

        public List<int> GetSubmissionChartData()
        {
            // Implementation using _context
            var submissionChartData = _context.AddStudents
                .Where(s => s.CreateDate >= DateTime.Now.AddDays(-30))
                .GroupBy(s => s.CreateDate.Date)
                .OrderBy(group => group.Key)
                .Select(group => group.Count())
                .ToList();

            return submissionChartData;
        }
        public List<int> GetAgeDistributionData()
        {
            var ageDistributionData = _context.AddStudents
                .Select(s => DateTime.Now.Year - s.DateOfBirth.Year)
                .GroupBy(age => age)
                .OrderBy(group => group.Key)
                .Select(group => group.Count())
                .ToList();

            return ageDistributionData;
        }

        public List<DepartmentDistributionData> GetDepartmentDistributionData()
        {
            var departmentDistribution = _context.AddStudents
                .GroupBy(s => s.Department)
                .Select(group => new DepartmentDistributionData
                {
                    Department = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return departmentDistribution;
        }
        public List<DegreeDistributionData> GetDegreeDistributionData()
        {
            var degreeDistribution = _context.AddStudents
                .GroupBy(s => s.DegreeTitle)
                .Select(group => new DegreeDistributionData
                {
                    DegreeTitle = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return degreeDistribution;
        }
        public List<GenderDistributionData> GetGenderDistributionData()
        {
            var genderDistribution = _context.AddStudents
                .GroupBy(s => s.Gender)
                .Select(group => new GenderDistributionData
                {
                    Gender = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return genderDistribution;
        }
        public List<ActivityData> GetLast30DaysActivityData()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30).Date;

            var activityData = _context.AddStudents
                .Where(s => s.CreateDate.Date >= thirtyDaysAgo)
                .GroupBy(s => s.CreateDate.Date)
                .Select(group => new ActivityData
                {
                    Date = group.Key,
                    ActionCount = group.Count()
                })
                .OrderBy(data => data.Date)
                .ToList();

            return activityData;
        }
        public List<int> GetMostActiveHoursLast30Days()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var mostActiveHours = _context.AddStudents
                .Where(s => s.CreateDate >= thirtyDaysAgo)
                .GroupBy(s => s.CreateDate.Hour)
                .Select(group => new
                {
                    Hour = group.Key,
                    ActionCount = group.Count()
                })
                .OrderByDescending(data => data.ActionCount)
                .Take(5) // Adjust the number of hours you want to retrieve
                .Select(data => data.Hour)
                .ToList();

            return mostActiveHours;
        }

        public StudentStatusData GetStudentStatusData()
        {

            var students = _context.AddStudents.ToList(); // Retrieve all students from the database

            var statusData = new StudentStatusData
            {
                CurrentlyStudying = students.Count(s => s.StartDate <= s.CreateDate && s.EndDate > s.CreateDate.AddYears(-4)),
                RecentlyEnrolled = students.Count(s => s.CreateDate >= s.CreateDate.AddMonths(-1)),
                AboutToGraduate = students.Count(s => (s.EndDate - s.StartDate).TotalDays >= 42 * 30 && s.EndDate <= s.CreateDate.AddMonths(6)),
                Graduated = students.Count(s => s.EndDate <= s.CreateDate && s.StartDate <= s.CreateDate.AddYears(-4)),
            };


            return statusData;
        }



        public List<int> GetLeastActiveHoursLast30Days()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var leastActiveHours = _context.AddStudents
                .Where(s => s.CreateDate >= thirtyDaysAgo)
                .GroupBy(s => s.CreateDate.Hour)
                .Select(group => new
                {
                    Hour = group.Key,
                    ActionCount = group.Count()
                })
                .OrderBy(data => data.ActionCount)
                .Take(5) // Adjust the number of hours you want to retrieve
                .Select(data => data.Hour)
                .ToList();

            return leastActiveHours;
        }
        public List<int> GetDeadHoursLast30Days(int threshold = 1)
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var deadHours = _context.AddStudents
                .Where(s => s.CreateDate >= thirtyDaysAgo)
                .GroupBy(s => s.CreateDate.Hour)
                .Select(group => new
                {
                    Hour = group.Key,
                    ActionCount = group.Count()
                })
                .Where(data => data.ActionCount <= threshold)
                .Select(data => data.Hour)
                .ToList();

            return deadHours;
        }



    }
}
