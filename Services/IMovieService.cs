using AppDisney.Models;
using AppDisney.ViewModels;
using AppDisney.ViewModels.MovieOrSerieViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDisney.Services
{
    public interface IMovieService : IEntityBaseService<MovieOrSerie>
    {
        Task<IEnumerable<GetMovieDetailsVM>> GetAll();
        Task<MovieOrSerie> GetDetails(int id);
        IQueryable<MovieOrSerie> GetByName(string name);
        IQueryable<MovieOrSerie> MovieFilter(string genre);
        Task CreateMovie(CreateMovieVM model);
        Task UpdateMovie(UpdateMovieVM model);
        bool Exists(string name);
        bool Exists(int id);
    }
}
