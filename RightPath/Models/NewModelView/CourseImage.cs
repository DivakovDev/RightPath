using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models.NewModelView
{
    public class CourseImage
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Име на Курса")]
        [Required(ErrorMessage = "Името е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да бъде до 50 символа!")]
        public string CourseTitle { get; set; }

        [DisplayName("Описание на Курса")]
        [Required(ErrorMessage = "Описанието е задължително")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Описанието трябва да бъде повече от 3 символа!")]
        public string CourseDescription { get; set; }

        [DisplayName("Времетраене")]
        [Required(ErrorMessage = "Времетраенето задължително трябва да бъде в часове!")]
        public double CourseDuration { get; set; }

        [DisplayName("Корица на Курса")]
        [Required(ErrorMessage = "Корицата е задължителна!")]
        public IFormFile CourseLogo { get; set; }

        [DisplayName("Водещ Лектор")]
        [Required(ErrorMessage = "Водещия лектор е задължителен")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на Водещия лектор е задължително!")]
        public string Lecture1 { get; set; }

        [Display(Name = "Помощник Лектор")]
        public string Lecture2 { get; set; }
    }
}
