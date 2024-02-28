using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RightPath.Models;

namespace RightPath.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public PasswordHasher<ApplicationUser> _hasher;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create user
            var appicationUser = new ApplicationUser
            {
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
               
            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appicationUser.PasswordHash = ph.HashPassword(appicationUser, "123456");

            //seed user
            modelBuilder.Entity<ApplicationUser>().HasData(appicationUser);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts {get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Webminar> Webminars{ get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
