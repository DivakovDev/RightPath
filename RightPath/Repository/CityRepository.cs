using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;
using System.Linq.Expressions;

namespace RightPath.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(City obj)
        {
            _context.Cities.Update(obj);
        }
    }
}
