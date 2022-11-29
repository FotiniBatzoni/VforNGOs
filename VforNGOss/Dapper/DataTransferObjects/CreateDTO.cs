using System.ComponentModel.DataAnnotations;

namespace VforNGOss.DataTransefObjects
{
    public class CreateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public String Email{ get; set; }
    }
}
