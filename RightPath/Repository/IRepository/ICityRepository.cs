using RightPath.Models;

namespace RightPath.Repository.IRepository
{
    public interface ICityRepository : IRepository<City>
    {
        void Update(City obj);
        void Save();
    }
}
