using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;

namespace RightPath.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //We have update because we update manually every things without issues
        public void Update(Course obj)
        {
            var objFormDb = _context.Courses.FirstOrDefault(u => u.Id == obj.Id);
            if (objFormDb != null)
            {
                objFormDb.Title = obj.Title;
                objFormDb.Description = obj.Description;
                objFormDb.Duration = obj.Duration;
                objFormDb.Lecture1Id = obj.Lecture1Id;
                if (obj.Logo != null)
                {
                    objFormDb.Logo = obj.Logo;
                }
            }
        }
    }
}
