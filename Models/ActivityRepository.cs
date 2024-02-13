using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ProjectStudentSystem.Models
{
    public class ActivityRepository
    {
        private readonly ActivityContext _context;

        public ActivityRepository(ActivityContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void AddActivity(string activity)
        {
            Activity Active = new Activity();
            Active.Activity1 = activity;
            Active.CreateDate = DateTime.Now;
            ActivityContext sx = new ActivityContext();
            sx.Activitys.Add(Active);
            sx.SaveChanges();
        }
        public List<ActivityChartData> GetLast30DaysActivityData()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var activityData = _context.Activitys
                .Where(a => a.CreateDate >= thirtyDaysAgo)
                .GroupBy(a => a.CreateDate.Date)
                .Select(group => new ActivityChartData
                {
                    Date = group.Key,
                    ActionCount = group.Count()
                })
                .OrderBy(data => data.Date)
                .ToList();

            return activityData;
        }


        public class ActivityData
        {
            public DateTime Date { get; set; }
            public int ActionCount { get; set; }
        }

        public List<ActivityData> GetLast24HoursActivityData()
        {
            var twentyFourHoursAgo = DateTime.Now.AddHours(-24);
            var fifteenMinutesInterval = TimeSpan.FromMinutes(15);

            var activityData = new List<ActivityData>();

            var intervals = Enumerable.Range(0, 96)
                .Select(i => twentyFourHoursAgo.AddMinutes(i * 15));

            foreach (var interval in intervals)
            {
                var count = _context.Activitys
                    .Count(a => a.CreateDate >= interval && a.CreateDate < interval.Add(fifteenMinutesInterval));

                activityData.Add(new ActivityData
                {
                    Date = interval,
                    ActionCount = count
                });
            }

            return activityData;
        }



    }
}
