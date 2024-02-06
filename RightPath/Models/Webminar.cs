using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightPath.Models
{
    public class Webminar : IProduct
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително!")]
        [DisplayName("Име на Уебминар")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описанието е задължително!")]
        [DisplayName("Описание на Уебминар")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Началната дата е задължителна!")]
        [DisplayName("Начална Дата")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Локацията е задължителна!")]
        [DisplayName("Локация на Събитието")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        [ValidateNever]
        public City City { get; set; }

        [Required(ErrorMessage = "Корицата е задължителна")]
        [DisplayName("Снимка на Уебминара")]
        [ValidateNever]
        public string Logo{ get; set; }

        [Required(ErrorMessage = "Водещият Лектор е задължителен!")]
        [DisplayName("Водещ Лектор")]
        public int Lecture1Id { get; set; }
        [ForeignKey("Lecture1Id")]
        [ValidateNever]
        public Lecture Lecture { get; set; }

        //Relation for Webminar
        //public List<Webminar_Lector> Webminars_Lectures { get; set; }

    }
}
