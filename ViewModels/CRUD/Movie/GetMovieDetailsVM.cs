using AppDisney.Models;
using System;
using System.Collections.Generic;

namespace AppDisney.ViewModels
{
    public class GetMovieDetailsVM
    {
        public string Image { get; set; } 
        public string Name { get; set; } 
        public DateTime CreatedAt { get; set; }
        public int Calification { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
        public Genre Genre { get; set; } = new Genre();
    }
}
