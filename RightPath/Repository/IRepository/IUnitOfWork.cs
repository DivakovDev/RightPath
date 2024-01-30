﻿namespace RightPath.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICityRepository City { get; }
        IWebminarRepository Webminar { get; }

        ILectureRepository Lecture { get; }

        ICourseRepository Course { get; }

        void Save();
    }
}
