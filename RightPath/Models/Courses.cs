using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public  string CourseTitle { get; set; }

        [Required]
        public string CourseDescription { get; set; }

        [Required]
        public double CourseDuration { get; set; }

        [Required]
        public string Lecture1 { get; set; }

        public string Lecture2 { get; set; }

    }
}
