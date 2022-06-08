using AppDisney.Models;
using AppDisney.ViewModels;
using AppDisney.ViewModels.CharacterViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDisney.Services
{
    public interface ICharacterService : IEntityBaseService<Character>
    {
        Task<IEnumerable<GetCharListVM>> GetAll();
        Task<Character> GetDetails(int id);
        IQueryable<Character> GetByName(string name);
        IQueryable<Character> CharFilter(int age, float weight, int movieId);
        Task CreateChar(CreateCharVM model);
        Task UpdateChar(UpdateCharVM model);
        bool Exists(string name);        
        bool Exists(int id);
    }
}
