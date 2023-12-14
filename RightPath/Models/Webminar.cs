using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Webminar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string WebminarDescription { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public string WebminarLocation { get; set; }

        [Required]
        public string WebminarLogo{ get; set; }

        [Required]
        public string Lecture1 { get; set; } 

        public string Lecture2 { get; set; }

        public List<City> Cities { get; set; }

        //Realtion for Course
        public List<Course_Lector> Courses_Lectures { get; set; }

        //Relation for Webminar
        public List<Webminar_Lector> Webminars_Lectures { get; set; }

    }
}
