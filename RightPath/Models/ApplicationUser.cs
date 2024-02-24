using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class ApplicationUser: IdentityUser
    {
        public int Id {  get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EGN {  get; set; }

    }
}
