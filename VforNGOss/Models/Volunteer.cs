using System.ComponentModel.DataAnnotations;

namespace VforNGOss.Models
{
    public class Volunteer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //public int DateOfBirth { get; set; }

        //public string City { get; set; }

        //public string Education { get; set; }

    }
}

