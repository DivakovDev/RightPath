using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Lecture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LectureName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string LectureDescription { get; set; }

        [Required]
        public string ProfileImage { get; set; }

        //Realtion for Course
        public List<Course_Lector> Courses_Lectures { get; set; }


        //Relation for Webminar
        public List<Webminar_Lector> Webminars_Lectures { get; set; }





    }
}
