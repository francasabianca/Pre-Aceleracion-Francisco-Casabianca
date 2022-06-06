using System.ComponentModel.DataAnnotations;

namespace AppDisney.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
