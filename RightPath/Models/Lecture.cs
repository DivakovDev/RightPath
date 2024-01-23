using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Lecture
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително!")]
        [DisplayName("Име на Лектор")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описанието е задължително!")]
        [DisplayName("Описание на Лектор")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Профилната снимка е задължителна!")]
        [DisplayName("Профилна Снимка")]
        public string ProfileImage { get; set; }

        ////Realtion for Course
        //public List<Course_Lector> Courses_Lectures { get; set; }


        ////Relation for Webminar
        //public List<Webminar_Lector> Webminars_Lectures { get; set; }





    }
}
