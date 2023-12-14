using RightPath.Models;

namespace RightPath.Data
{
    public class AppDbInitializator
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var seviceScope =
                applicationBuilder.ApplicationServices.CreateScope())
            {
                var context= seviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if(!context.Lectures.Any())
                {
                    context.Lectures.AddRange(new List<Lecture>()
                    {
                        new Lecture()
                        {
                            Id = 1,
                            LectureName = "Lector1",
                            LastName= "Lector1LastName",
                            LectureDescription = "Opicanie na  lector1",
                            ProfileImage = "/lecture1.png"

                        },
                        new Lecture()
                        {
                            Id = 2,
                            LectureName = "Lector2",
                            LastName= "Lector2LastName",
                            LectureDescription = "Opicanie na  lector2",
                            ProfileImage = "/lecture1.png"

                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
