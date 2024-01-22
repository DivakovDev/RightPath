using RightPath.Models;

namespace RightPath.Repository.IRepository
{
    public interface IWebminarRepository : IRepository<Webminar>
    {
        void Update(Webminar obj);
    }
}
