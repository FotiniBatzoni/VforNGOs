using System.ComponentModel.DataAnnotations;

namespace VforNGOss.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Activity { get; set; }
        public string City { get; set; }

    }
}
