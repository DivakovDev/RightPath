using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightPath.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public List<Webminar> Webminars { get; set; }

        public List<Course> Courses { get; set; }

        public string ApplicationUserId{ get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}
