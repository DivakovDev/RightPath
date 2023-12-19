using System.ComponentModel.DataAnnotations;

namespace RightPath.Models.NewModelView
{
    public class WebminarImage
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 chars")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string WebminarDescription { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Display(Name = "Webminar Location")]
        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Location must be between 3 and 50 chars")]
        public string WebminarLocation { get; set; }

        [Display(Name = "Webminar Logo")]
        [Required(ErrorMessage = "Webminar Logo is required")]
        public IFormFile WebminarLogo { get; set; }


        [Display(Name = "Lecture1")]
        [Required(ErrorMessage = "Lecture1 is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Lecture1 name must be between 3 and 50 chars")]
        public string Lecture1 { get; set; }

        [Display(Name = "Lecture2")]
        public string Lecture2 { get; set; }
    }
}
