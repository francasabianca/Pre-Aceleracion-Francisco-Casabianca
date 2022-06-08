using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDisney.Models
{
    public class MovieOrSerie : EntityBase
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Calification { get; set; }
        public List<CharacterMovie> CharacterMovies { get; set; }
        //navigation

        public int GenreId { get; set; }
        [ForeignKey ("GenreId")]
        public Genre Genre { get; set; } = new Genre();
    }
}
