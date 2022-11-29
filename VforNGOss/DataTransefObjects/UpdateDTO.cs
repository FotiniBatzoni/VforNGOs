using System.ComponentModel.DataAnnotations;

namespace VforNGOss.DataTransefObjects
{
    public class UpdateDTO
    {
        [Required]
        public String Email { get; set; }
    }
}
