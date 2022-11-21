using System.ComponentModel.DataAnnotations;

namespace VforNGOss.Models
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

