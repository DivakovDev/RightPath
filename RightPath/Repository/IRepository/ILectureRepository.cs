using RightPath.Models;

namespace RightPath.Repository.IRepository
{
    public interface ILectureRepository : IRepository<Lecture>
    {
        void Update(Lecture obj);
    }
}
