using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models.NewModelView
{
    public class LectureImage
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Име на Лектор")]
        [Required(ErrorMessage = "Името е задължително!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Името трябва да бъде 2 или повече символа!")]
        public string LectureName { get; set; }


        [DisplayName("Фамилно име на Лектор")]
        [Required(ErrorMessage = "Фамилното име е задължително!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Фамилното име трябва да бъде повече от 3 символа!")]
        public string LastName { get; set; }

        [DisplayName("Описание на Лектор")]
        [Required(ErrorMessage = "Описанието е задължително!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Описанието трябва да бъде повече от 3 символа!")]
        public string LectureDescription { get; set; }

        [DisplayName("Профилна Снимка на Лектор")]
        [Required(ErrorMessage = "Профилната Снимка е задължителна!")]
        public IFormFile ProfileImage { get; set; }
    }
}
