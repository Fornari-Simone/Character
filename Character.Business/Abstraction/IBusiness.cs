using Character.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Business.Abstraction
{
    public interface IBusiness
    {
        Task AddCharacter(CharacterDTO characterDTO, CancellationToken cancellation = default);
        Task<CharacterDTO?> GetCharacter(int ID, CancellationToken cancellation = default);
        Task RemoveCharacter(int ID, CancellationToken cancellation = default);
        Task LevelUP(int ID, int level, CancellationToken cancellation = default);
        Task Ascend(int ID, CancellationToken cancellation = default);

    }
}
