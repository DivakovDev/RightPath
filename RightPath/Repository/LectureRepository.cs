using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;

namespace RightPath.Repository
{
    public class LectureRepository : Repository<Lecture>, ILectureRepository
    {
        private ApplicationDbContext _context;

        public LectureRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Lecture obj)
        {
            _context.Lectures.Update(obj);
        }
    }
}
