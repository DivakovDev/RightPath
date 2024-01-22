using RightPath.Models;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Data
{
    public class AppDbinitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
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
                            Name = "Lector1",
                            LastName= "Lector1LastName",
                            Description = "Opicanie na  lector1",
                            ProfileImage = "lecture1.png"

                        },
                        new Lecture()
                        {
                            Name = "Lector2",
                            LastName= "Lector2LastName",
                            Description = "Opicanie na  lector2",
                            ProfileImage = "lecture1.png"

                        },
                        new Lecture()
                        {
                            Name = "Lector2",
                            LastName= "Lector2LastName",
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
                                Lecture1Id = 1,
                                Lecture2Id = 2,

                            },
                            new Course()
                            {
                                Title = "Back End Developer Course",
                                Description= "You will learn how to be back end developer from the basics!",
                                Duration = 11.30,
                                Logo = "lecture1.png",
                                Lecture1Id = 3,
                                Lecture2Id = 2,

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
                                Lecture1Id = 3,
                                Lecture2Id = 2

                            },
                            new Webminar()
                            {
                                Title = "WebMinnar",
                                Description = "You will learn about sofia underground",
                                StartDate = new DateTime(2023, 12, 24),
                                CityId = 1,
                                Logo = "lecture1.png",
                                Lecture1Id = 1,
                                Lecture2Id = 3

                            },
                            new Webminar()
                            {
                                Title = "Sofia WebMinnar",
                                Description = "You will learn about sofia underground",
                                StartDate = new DateTime(2023, 12, 24),
                                CityId = 1,
                                Logo = "lecture1.png",
                                Lecture1Id = 1,
                                Lecture2Id = 2

                            },
                        });

                    context.SaveChanges();
                }
            }
        }
    }

} 
        
