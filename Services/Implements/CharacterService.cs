﻿using AppDisney.Models;
using AppDisney.Repositories;
using System.Linq;
using System;
using AppDisney.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppDisney.ViewModels.CharacterViewModel;

namespace AppDisney.Services.Implements
{
    public class CharacterService : EntityBaseService<Character>, ICharacterService
    {
        private readonly ICharacterRepository _repository;
        public CharacterService(ICharacterRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public IQueryable<Character> GetByName(string name)
        {
            if (!_repository.Exists(name))
            {
                throw new NullReferenceException("Character not found");
            }

            return _repository.GetByName(name);
        }

        public async Task<Character> GetDetails(int id)
        {
            return await _repository.GetDetails(id);
        }

        public Task<IEnumerable<GetCharListVM>> GetAll()
        {
            return _repository.GetAll();
        }           

        public IQueryable<Character> CharFilter(int age, float weight, int movieId)
        {
            var filtered = _repository.CharFilter(age, weight, movieId);

            return filtered;
        }

        public Task CreateChar(CreateCharVM model)
        {
            return  _repository.CreateChar(model);
        }

        public Task UpdateChar(UpdateCharVM model)
        {
            return _repository.UpdateChar(model);
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
