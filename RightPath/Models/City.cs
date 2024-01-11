using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Името на Града е задължително!")]
        [StringLength(30)]
        [DisplayName("Име на Града")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Номера на града е задължителен!")]
        [DisplayName("Номер на показване на града")]
        [Range(0, 30)]
        public int DisplayOrder { get; set; }
    }
}
