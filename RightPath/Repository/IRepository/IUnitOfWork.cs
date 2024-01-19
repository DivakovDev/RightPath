namespace RightPath.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICityRepository City { get; }

        void Save();
    }
}
