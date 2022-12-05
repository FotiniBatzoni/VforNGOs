using System.ComponentModel.DataAnnotations;

namespace VforNGOss.Models
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Education { get; set; }




    }
}

