using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
