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
                            
                            LectureName = "Lector1",
                            LastName= "Lector1LastName",
                            LectureDescription = "Opicanie na  lector1",
                            ProfileImage = "lecture1.png"

                        },
                        new Lecture()
                        {
                            
                            LectureName = "Lector2",
                            LastName= "Lector2LastName",
                            LectureDescription = "Opicanie na  lector2",
                            ProfileImage = "lecture1.png"

                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Courses.Any())
                {

                    context.Courses.AddRange(new List<Course>()
                        {
                            new Course()
                            {
                                CourseTitle = "Full Stack Developer Course",
                                CourseDescription= "You will learn how to be full stack developer from the basics!",
                                CourseDuration = 12.30,
                                CourseLogo = "lecture1.png",
                                Lecture1 = "Yuli Farhson",
                                Lecture2 = "Yuli Robertson",

                            },
                            new Course()
                            {
                                CourseTitle = "Back End Developer Course",
                                CourseDescription= "You will learn how to be back end developer from the basics!",
                                CourseDuration = 11.30,
                                CourseLogo = "lecture1.png",
                                Lecture1 = "Duncun Harfkak",
                                Lecture2 = "Joe Hudson",

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
                                WebminarDescription = "You will learn about sofia underground",
                                StartDate = new DateTime(2023, 12, 24),
                                EndDate = new DateTime(2023, 12, 25), 
                                WebminarLocation = "Sofia",
                                WebminarLogo = "lecture1.png",
                                Lecture1 = "Harry Maguire",
                                Lecture2 = "Jonny Sins"

                            },
                            new Webminar()
                            {
                                Title = "NoWebminar",
                                WebminarDescription = "You will learn about how to invest",
                                StartDate = new DateTime(2023, 12, 20),
                                EndDate = new DateTime(2023, 12, 21),
                                WebminarLocation = "Sofia, Marinaela hotel",
                                WebminarLogo = "lecture1.png",
                                Lecture1 = "Harry Maguire",
                                Lecture2 = "Jonny Sins"

                            },
                        });

                    context.SaveChanges();
                }
            }
        }
    }

} 
        
