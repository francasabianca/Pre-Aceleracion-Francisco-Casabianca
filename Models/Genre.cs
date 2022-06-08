using System;
using System.Collections.Generic;

namespace AppDisney.Models
{
    public class Genre : EntityBase
    {
        public List<MovieOrSerie> MoviesOrSeries { get; set; }
    }
}
