using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително!")]
        [DisplayName("Име на Курса")]
        public string CourseTitle { get; set; }

        [Required(ErrorMessage = "Описанието е задължително!")]
        [DisplayName("Описание на Курса")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "Времетраенето задължително трябва да бъде в часове!")]
        [DisplayName("Времетраене на Курса")]
        public double CourseDuration { get; set; }

        [Required(ErrorMessage = "Корицата е задължителна!")]
        [DisplayName("Корица на Курса")]
        public string CourseLogo { get; set; }

        [Required(ErrorMessage = "Водещия лектор е задължителен!")]
        [DisplayName("Водещ Лектор")]
        public string Lecture1 { get; set; }

        [Required(ErrorMessage = "Помощник лектора е задължителен!")]
        [DisplayName("Помощник Лектор")]
        public string Lecture2 { get; set; }

        //Relation
        public List<Course_Lector> Courses_Lectures { get; set; }

    }
}
