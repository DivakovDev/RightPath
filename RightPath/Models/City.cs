using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Име на Града")]
        public string Name { get; set; }
        [DisplayName("Покажи поръчката")]
        [Range(0, 30)]
        public int DisplayOrder { get; set; }
    }
}
