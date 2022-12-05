using System.ComponentModel.DataAnnotations;

namespace VforNGOss.Models
{
    public class Organization
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
