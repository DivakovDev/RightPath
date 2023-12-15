using System.ComponentModel.DataAnnotations;

namespace RightPath.Models.NewModelView
{
    public class LectureImage
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string LectureName { get; set; }


        [Display(Name = "LastName")]
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string LastName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string LectureDescription { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public IFormFile ProfileImage { get; set; }
    }
}
