using AppDisney.Models;
using AppDisney.Repositories;
using AppDisney.ViewModels;
using AppDisney.ViewModels.MovieOrSerieViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDisney.Services.Implements
{
    public class MovieService : EntityBaseService<MovieOrSerie>, IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public IQueryable<MovieOrSerie> GetByName(string name)
        {          
            return _repository.GetByName(name);
        }

        public async Task<MovieOrSerie> GetDetails(int id)
        {
            return await _repository.GetDetails(id);
        }

        public Task<IEnumerable<GetMovieDetailsVM>> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<MovieOrSerie> MovieFilter(string genre)
        {
            var filtered = _repository.MovieFilter(genre);

            return filtered;
        }

        public Task CreateMovie(CreateMovieVM model)
        {
            return _repository.CreateMovie(model);
        }

        public Task UpdateMovie(UpdateMovieVM model)
        {
            return _repository.UpdateMovie(model);
        }
        public bool Exists(string name)
        {
            return _repository.Exists(name);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
