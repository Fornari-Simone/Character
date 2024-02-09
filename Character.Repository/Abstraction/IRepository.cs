using Character.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Repository.Abstraction
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
        Task AddCharacter(CharacterDb character, CancellationToken cancellation = default);
        Task<CharacterDb?> GetCharacter(int ID, CancellationToken cancellation = default);
        Task RemoveCharacter(CharacterDb? character, CancellationToken cancellation = default);
        Task UpdateCharacter(CharacterDb? character, CancellationToken cancellation = default);

        // TransationalOutbox
        Task DeleteTransactionalOutbox(long ID, CancellationToken cancellation);
        Task<TransactionalOutbox?> GetAllTransactionalOutboxByKey(long ID, CancellationToken cancellation = default);
        Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellation);
        Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellation = default);
    }
}
