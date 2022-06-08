using AppDisney.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppDisney.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterMovie>().HasKey(am => new
            {
                am.MovieOrSerieId,
                am.CharacterId
            });

            modelBuilder.Entity<CharacterMovie>()
                .HasOne(x => x.MovieOrSerie)
                .WithMany(a => a.CharacterMovies)
                .HasForeignKey(c => c.MovieOrSerieId);

            modelBuilder.Entity<CharacterMovie>()
                .HasOne(x => x.Character)
                .WithMany(a => a.CharacterMovies)
                .HasForeignKey(c => c.CharacterId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CharacterMovie> CharacterMovies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieOrSerie> MoviesOrSeries { get; set; }
    }
}
