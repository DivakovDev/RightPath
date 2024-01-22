using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;

namespace RightPath.Repository
{
    public class WebminarRepository : Repository<Webminar>, IWebminarRepository
    {
        private ApplicationDbContext _context;

        public WebminarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Webminar obj)
        {
            _context.Webminars.Update(obj);
        }
    }
}
