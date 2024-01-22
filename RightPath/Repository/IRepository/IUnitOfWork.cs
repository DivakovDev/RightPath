namespace RightPath.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICityRepository City { get; }
        IWebminarRepository Webminar { get; }

        void Save();
    }
}
