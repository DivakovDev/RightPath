using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class Webminars
    {
        [Key]
        public int WebminarId { get; set; }

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
        public string Lecture1 { get; set; } 

        public string Lecture2 { get; set; }
    }
}
