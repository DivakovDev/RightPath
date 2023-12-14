using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public  string CourseTitle { get; set; }

        [Required]
        public string CourseDescription { get; set; }

        [Required]
        public double CourseDuration { get; set; }

        [Required]
        public string CourseLogo { get; set; }

        [Required]
        public string Lecture1 { get; set; }

        public string Lecture2 { get; set; }

        //Relation
        public List<Course_Lector> Courses_Lectures { get; set; }

    }
}
