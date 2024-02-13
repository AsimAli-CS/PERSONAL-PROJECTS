using Microsoft.EntityFrameworkCore;

namespace ProjectStudentSystem.Models
{
    public class InterestRepository
    {
        private readonly InterestContext _context;

        public InterestRepository(InterestContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Interest> GetAllInterests()
        {
            return _context.Interests.ToList();
        }

        public void AddSignUpInfo(Interest s)
        {
            
            InterestContext sx = new InterestContext();
            sx.Interests.Add(s);
            sx.SaveChanges();
        }

       

    }
}
