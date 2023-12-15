using RightPath.Models;

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
            }
        }
    }

} 
        
