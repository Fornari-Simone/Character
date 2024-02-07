using Character.Business.Abstraction;
using Character.Repository.Abstraction;
using Character.Repository.Model;
using Character.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Business
{
    public class Business : IBusiness
    {
        private readonly IRepository _repository;
        private readonly ILogger<Business> _logger;
        public Business(IRepository repository, ILogger<Business> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task AddCharacter(CharacterDTO characterDTO, CancellationToken cancellation = default)
        {

            await _repository.AddCharacter(new CharacterDb
            {
                Name = characterDTO.Name,
                Star = characterDTO.Star,
                Class = characterDTO.Class,
                Subclass = characterDTO.Subclass,
                Elite = characterDTO.Elite,
                Level = characterDTO.Level,
                Trait = characterDTO.Trait,
            }, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task Ascend(int ID, CancellationToken cancellation = default)
        {
            await _repository.UpdateCharacter(new CharacterDb
            {
                Elite = 1,
            }, ID, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task<CharacterDTO?> GetCharacter(int ID, CancellationToken cancellation = default)
        {
            CharacterDb? characterDb = await _repository.GetCharacter(ID, cancellation);
            if (characterDb == null) { return null; }
            return new CharacterDTO
            {
                ID = characterDb.ID,
                Name = characterDb.Name,
                Star = characterDb.Star,
                Class = characterDb.Class,
                Subclass = characterDb.Subclass,
                Elite = characterDb.Elite,
                Level = characterDb.Level,
                Trait = characterDb.Trait,
            };
        }

        public async Task LevelUP(int ID, int level, CancellationToken cancellation = default)
        {
            await _repository.UpdateCharacter(new CharacterDb
            {
                Elite = 0,
                Level = level,
            }, ID, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task RemoveCharacter(int ID, CancellationToken cancellation = default)
        {
            CharacterDb? characterDb = await _repository.GetCharacter(ID, cancellation);
            if (characterDb == null) { return; }
            await _repository.RemoveCharacter(characterDb, cancellation);
            await _repository.SaveChangesAsync(cancellation);
        }
    }
}
