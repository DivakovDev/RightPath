using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Webminar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително!")]
        [DisplayName("Име на Уебминар")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Описанието е задължително!")]
        [DisplayName("Описание на Уебминар")]
        public string WebminarDescription { get; set; }

        [Required(ErrorMessage = "Началната дата е задължителна!")]
        [DisplayName("Начална Дата")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Крайната дата е задължителна!")]
        [DisplayName("Крайна Дата")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Локацията е задължителна!")]
        [DisplayName("Локация на Събитието")]
        public string WebminarLocation { get; set; }

        [Required(ErrorMessage = "Корицата е задължителна")]
        [DisplayName("Снимка на Уебминара")]
        public string WebminarLogo{ get; set; }

        [Required(ErrorMessage = "Водещият Лектор е задължителен!")]
        [DisplayName("Водещ Лектор")]
        public string Lecture1 { get; set; }

        [Required(ErrorMessage = "Помощник лектора е задължителен!")]
        [DisplayName("Помощник Лектор")]
        public string Lecture2 { get; set; }

        //Relation for Webminar
        public List<Webminar_Lector> Webminars_Lectures { get; set; }

    }
}
