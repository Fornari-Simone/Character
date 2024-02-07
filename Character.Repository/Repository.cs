using Character.Repository.Abstraction;
using Character.Repository.Model;

namespace Character.Repository
{
    public class Repository : IRepository
    {
        private CharacterDbContext _context;
        public Repository(CharacterDbContext characterDbContext)
        {
            _context = characterDbContext;
        }
        public async Task AddCharacter(CharacterDb character, CancellationToken cancellation = default)
        {
            await _context.CharacterDb.AddAsync(character, cancellation);
        }

        public async Task<CharacterDb?> GetCharacter(int ID, CancellationToken cancellation = default)
        {
            return await _context.CharacterDb.FindAsync(ID, cancellation);
        }

        public async Task RemoveCharacter(CharacterDb? character, CancellationToken cancellation = default)
        {
            _context.CharacterDb.Remove(character);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            return await _context.SaveChangesAsync(cancellation);
        }

        public async Task UpdateCharacter(CharacterDb? character, int ID, CancellationToken cancellation = default)
        {
            CharacterDb? characterDb = await this.GetCharacter(ID, cancellation);
            if (characterDb != null && character != null) 
            {
                if (character.Elite > 0)
                {
                    characterDb.Elite++;
                    characterDb.Level = 1;
                }
                else if (character.Level != 0 && character.Level > characterDb.Level)
                    characterDb.Level = character.Level;
            }
        }
    }
}
