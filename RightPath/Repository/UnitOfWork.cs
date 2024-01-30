﻿using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;

namespace RightPath.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICityRepository City { get; private set; }
        public IWebminarRepository Webminar { get; private set; }

        public ILectureRepository Lecture { get; private set; }

        public ICourseRepository Course { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            City = new CityRepository(_context);
            Webminar = new WebminarRepository(_context);
            Lecture = new LectureRepository(_context);
            Course = new CourseRepository(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
