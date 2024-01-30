using RightPath.Models;

namespace RightPath.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Update(Course obj);
    }
}
