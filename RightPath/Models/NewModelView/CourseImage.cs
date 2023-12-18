using System.ComponentModel.DataAnnotations;

namespace RightPath.Models.NewModelView
{
    public class CourseImage
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Course Logo")]
        [Required(ErrorMessage = "Course Logo is required")]
        public IFormFile CourseLogo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string CourseTitle { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Description must be between 3 and 50 chars")]
        public string CourseDescription { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessage = "Duration is required and must be real hours!")]
        public double CourseDuration { get; set; }

        [Display(Name = "Lecture1")]
        [Required(ErrorMessage = "Lecture1 is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Lecture1 name must be between 3 and 50 chars")]
        public string Lecture1 { get; set; }

        [Display(Name = "Lecture2")]
        public string Lecture2 { get; set; }
    }
}
