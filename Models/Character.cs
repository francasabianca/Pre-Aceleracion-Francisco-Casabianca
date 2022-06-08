using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDisney.Models
{
    public class Character : EntityBase
    {
        public int? Age { get; set; }
        public int? Weight { get; set; }
        public string History { get; set; } = string.Empty;       
        
        //navigation
        public List<CharacterMovie> CharacterMovies { get; set; }
    }
}
