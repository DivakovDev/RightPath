using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;
using System.Linq.Expressions;

namespace RightPath.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
