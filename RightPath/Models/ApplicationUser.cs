using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string EGN {  get; set; }

    }
}
