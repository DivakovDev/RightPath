using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using RightPath.Models;
using RightPath.Repository;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Data
{
    public class AppDbinitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Lectures.Any())
                {

                    context.Lectures.AddRange(new List<Lecture>()
                    {
                       new Lecture()
                        {
                            Name = "Юли Тонкин",
                            Description = "Opicanie na  lector1",
                            ProfileImage = "lecture1.png"

                        },
                        new Lecture()
                        {
                            Name = "Боян Московски",
                            Description = "Opicanie na  lector2",
                            ProfileImage = "lecture1.png"

                        },
                        new Lecture()
                        {
                            Name = "Кристиян Валидолов",
                            Description = "Opicanie na  lector2",
                            ProfileImage = "lecture1.png"
                        }
                    }) ;

                    context.SaveChanges();
                }

                if (!context.Courses.Any())
                {

                    context.Courses.AddRange(new List<Course>()
                        {
                            new Course()
                            {
                                Title = "Full Stack Developer Course",
                                Description= "You will learn how to be full stack developer from the basics!",
                                Duration = 12.30,
                                Logo = "lecture1.png",
                                LectureId = 1

                            },
                            new Course()
                            {
                                Title = "Back End Developer Course",
                                Description= "You will learn how to be back end developer from the basics!",
                                Duration = 11.30,
                                Logo = "lecture1.png",
                                LectureId = 3

                            },
                        });

                    context.SaveChanges();
                }

                if (!context.Cities.Any())
                {

                    context.Cities.AddRange(new List<City>()
                    {
                       new City()
                       {
                          Name = "София",
                          DisplayOrder = 1
                       },
                       new City()
                       {
                          Name = "Пловдив",
                          DisplayOrder = 2
                       },
                       new City()
                       {
                          Name = "Варна",
                          DisplayOrder = 3
                       },
                       new City()
                       {
                          Name = "Бургас",
                          DisplayOrder = 4
                       },
                       new City()
                       {
                          Name = "Русе",
                          DisplayOrder = 5
                       },
                    });

                    context.SaveChanges();
                }

                if (!context.Webminars.Any())
                {

                    context.Webminars.AddRange(new List<Webminar>()
                        {
                            new Webminar()
                            {
                                Title = "Sofia Streets WebMinnar",
                                Description = "You will learn about sofia underground",
                                StartDate = new DateTime(2023, 12, 24),
                                CityId = 1,
                                Logo = "lecture1.png",
                                LectureId = 3

                            },
                            new Webminar()
                            {
                                Title = "WebMinnar",
                                Description = "You will learn about sofia underground",
                                StartDate = new DateTime(2023, 12, 24),
                                CityId = 1,
                                Logo = "lecture1.png",
                                LectureId = 1

                            },
                            new Webminar()
                            {
                                Title = "Sofia WebMinnar",
                                Description = "You will learn about sofia underground",
                                StartDate = new DateTime(2023, 12, 24),
                                CityId = 1,
                                Logo = "lecture1.png",
                                LectureId = 1

                            },
                        });

                    context.SaveChanges();
                }
            }

            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { StaticDetail.Role_Customer, StaticDetail.Role_Admin, StaticDetail.Role_Lecture };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }


                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string email = "admin@gmail.com";
                string password = "123456";
                string egn = "081295412";
                string phoneNum = "08820784322";
                string firstName = "Admin";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser
                    {
                        FirstName = firstName,
                        UserName = email,
                        Email = email,
                        EGN = egn,
                        PhoneNumber = phoneNum,
                    };

                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, StaticDetail.Role_Admin);
                    }
                }

            }
        }
    }

} 
        
