using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RightPath.Models;

namespace RightPath.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course_Lector>().HasKey(cl => new
            {
                cl.CourseId,
                cl.LectureId
            });

            modelBuilder.Entity<Course_Lector>().HasOne(m => m.Course).WithMany(cl => cl.Courses_Lectures).HasForeignKey(c => c.CourseId);
            modelBuilder.Entity<Course_Lector>().HasOne(m => m.Lecture).WithMany(cl => cl.Courses_Lectures).HasForeignKey(c => c.LectureId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Webminar_Lector>().HasKey(wl => new
            {
                wl.WebminarId,
                wl.LectureId
            });

            modelBuilder.Entity<Webminar_Lector>().HasOne(m => m.Webminar).WithMany(wl => wl.Webminars_Lectures).HasForeignKey(c => c.WebminarId);
            modelBuilder.Entity<Webminar_Lector>().HasOne(m => m.Lecture).WithMany(wl => wl.Webminars_Lectures).HasForeignKey(c => c.LectureId);

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Lector> Courses_Lectures { get; set; }
        public DbSet<Webminar_Lector> Webminars_Lectures { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        //public DbSet<UsersInfo> UsersInfo{ get; set; }
        public DbSet<Webminar> Webminars{ get; set; }

    }
}
