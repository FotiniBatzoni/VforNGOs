using System.ComponentModel.DataAnnotations;

namespace VforNGOss.Dapper.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
