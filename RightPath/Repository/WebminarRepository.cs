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

        //We have update because we update manually every things without issues
        public void Update(Webminar obj)
        {
            var objFormDb = _context.Webminars.FirstOrDefault(u => u.Id == obj.Id);
            if (objFormDb != null)
            {
                objFormDb.Title = obj.Title;
                objFormDb.Description = obj.Description;
                objFormDb.StartDate = obj.StartDate;
                objFormDb.CityId= obj.CityId;
                objFormDb.Lecture1Id= obj.Lecture1Id;
                if(obj.Logo != null)
                {
                    objFormDb.Logo = obj.Logo;
                }
            }
        }
    }
}
