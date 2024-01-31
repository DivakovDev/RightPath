using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EGN {  get; set; }



    }
}
