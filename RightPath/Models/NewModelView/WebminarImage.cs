using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models.NewModelView
{
    public class WebminarImage
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Име на Уебминара")]
        [Required(ErrorMessage = "Името е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да бъде 2 или повече символа!")]
        public string Title { get; set; }

        [DisplayName("Описание на Уебминара")]
        [Required(ErrorMessage = "Описанието е задължително")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Описанието трябва да бъде 3 или повече символа!")]
        public string WebminarDescription { get; set; }

        [DisplayName("Начална Дата")]
        [Required(ErrorMessage = "Началната дата е задължителна!")]
        public DateTime StartDate { get; set; }

        [DisplayName("Крайна Дата")]
        public DateTime EndDate { get; set; }

        [DisplayName("Локация на Уебминар")]
        [Required(ErrorMessage = "Локацията е задължителна!")]
        public string WebminarLocation { get; set; }

        [Display(Name = "Корица на Уебминар")]
        [Required(ErrorMessage = "Корицата е задължителна")]
        public IFormFile WebminarLogo { get; set; }


        [DisplayName("Водещ Лектор")]
        [Required(ErrorMessage = "Водещият Лектор е задължителен!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на Водещия лектор трябва да е повече от 10 символа!")]
        public string Lecture1 { get; set; }

        [DisplayName("Помощник Лектор")]
        public string Lecture2 { get; set; }
    }
}
