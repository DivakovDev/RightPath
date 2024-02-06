using System.ComponentModel.DataAnnotations.Schema;

namespace RightPath.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        List<IProduct> Products { get; set; }
        public string UserId{ get; set; }
    }
}
