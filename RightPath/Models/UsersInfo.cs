using System.ComponentModel.DataAnnotations;

namespace RightPath.Models
{
    public class UsersInfo
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }

        public string UserCourses { get; set; }

        public string UserWebminars{ get; set; }
    }
}
