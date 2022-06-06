using AppDisney.DataAccess;
using AppDisney.Models;
using AppDisney.ViewModels;
using AppDisney.ViewModels.CharacterViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AppDisney.Repositories.Implements
{
    public class CharacterRepository : EntityBaseRepository<Character>, ICharacterRepository
    {
        private readonly AppDBContext _context;

        public CharacterRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Character> GetByName(string name)
        {
            var query = _context.Characters.Where(n => n.Name.Contains(name));

            return query;
        }

        public IQueryable<Character> CharFilter(int age, float weight, int movieId)
        {
            var query = _context.Characters.Include(x => x.CharacterMovies).
                                            ThenInclude(c => c.MovieOrSerie.Genre).
                                            Where(x => x.Age == age || x.Weight == weight
                                            || x.CharacterMovies.Any(x => x.MovieOrSerieId
                                            == movieId));

            return query;
        }

        public async Task<Character> GetDetails(int id)
        {
            var currentChar = await _context.Characters.FirstAsync(
                x => x.Id == id);

            return currentChar;
        }

        public async Task<IEnumerable<GetCharListVM>> GetAll()
        {
            var charList = await _context.Characters.ToListAsync();

            var modelList = charList.Select(a => new GetCharListVM
            {
                Name = a.Name,
                Image = a.Image,
            });

            return modelList;
        }

        public async Task CreateChar(CreateCharVM model)
        {
            var newChar = new Character()
            {
                Name = model.Name,
                Age = model.Age,
                Image = model.Image,
                Weight = model.Weight,
                History = model.History,
            };

            await _context.Characters.AddAsync(newChar);
            await _context.SaveChangesAsync();

            foreach (var movieId in model.IdMovieOrSerie)
            {
                var newCharMovie = new CharacterMovie()
                {
                    CharacterId = model.Id,
                    MovieOrSerieId = movieId
                };
                await _context.CharacterMovies.AddAsync(newCharMovie);
            }
            await _context.SaveChangesAsync();
        }
        public async Task UpdateChar(UpdateCharVM model)
        {
            var dbChar = await _context.Characters.FirstOrDefaultAsync(n => n.Id == model.Id);

            if (dbChar != null)
            {
                dbChar.Name = model.Name;
                dbChar.Age = model.Age;
                dbChar.Image = model.Image;
                dbChar.Weight = model.Weight;
                dbChar.History = model.History;

                await _context.SaveChangesAsync();
            }
            
            var existingMoviesDB = _context.CharacterMovies.Where(n => n.CharacterId == model.Id).ToList();
            _context.CharacterMovies.RemoveRange(existingMoviesDB);
            await _context.SaveChangesAsync();
           
            foreach (var movieId in model.IdMovieOrSerie)
            {
                var newCharMovie = new CharacterMovie()
                {
                    CharacterId = model.Id,
                    MovieOrSerieId = movieId
                };

                await _context.CharacterMovies.AddAsync(newCharMovie);
            }

            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            var entity = _context.Characters.Any(x => x.Id == id);

            if (entity)
            {
                return true;
            }

            return false;
        }
        public bool Exists(string name)
        {
            var character = _context.Characters.FirstOrDefault(a =>
                a.Name.ToLower().Contains(name.ToLower()));

            if (character == null)
            {
                return false;
            }

            return true;
        }


    }
}

