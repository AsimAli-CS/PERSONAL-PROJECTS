namespace ProjectStudentSystem.Models
{
    //public class ActivityData
    //{
    //    public DateTime Date { get; set; }
    //    public int ActionCount { get; set; }
    //}
    public class DashboardViewModel
    {
        public List<string> Top5Interests { get; set; }
        public List<string> Bottom5Interests { get; set; }

        public int DistinctInterestCount { get; set; }

        // Add a property for City distribution
        public List<string> CityDistributionLabels { get; set; }
        public List<int> CityDistributionData { get; set; }

        public List<int> SubmissionChartData { get; set; }

        public List<int> AgeDistributionData { get; set; }

        public List<string> DepartmentDistributionLabels { get; set; }
        public List<int> DepartmentDistributionData { get; set; }
        public List<string> DegreeDistributionLabels { get; set; }
        public List<int> DegreeDistributionData { get; set; }
        public List<string> GenderDistributionLabels { get; set; }
        public List<int> GenderDistributionData { get; set; }
        
        public List<int> MostActiveHoursLast30Days { get; set; }
        public StudentStatusData StudentStatusData { get; set; }
        public List<int> LeastActiveHoursLast30Days { get; set; }
        public List<int> DeadHoursLast30Days { get; set; }

        public List<ActivityChartData> Last30DaysActivityData { get; set; }

        public List<DateTime> Last24HoursActivityData { get; set; }
        public List<int> Last24HoursActivityCounts { get; set; }
    }
}
