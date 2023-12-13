using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Lectures
    {
        [Key]
        public int LectureId { get; set; }

        [Required]
        public string LectureName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string LectureDescription { get; set; }
    }
}
