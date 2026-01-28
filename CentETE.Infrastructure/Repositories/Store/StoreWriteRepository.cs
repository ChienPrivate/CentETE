using CentETE.Application.Interfaces.Store;
using CentETE.Domain.Entities;
using CentETE.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CentETE.Infrastructure.Repositories.Store
{
    public class StoreWriteRepository : IStoreWriteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StoreWriteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Domain.Entities.Store store)
        {
            await _dbContext.Stores.AddAsync(store);
        }

        public async Task<bool> Delete(Guid id)
        {
            var store = await _dbContext.Stores.FirstOrDefaultAsync(s =>s.Id == id);

            if (store is null)
            {
                return false;
            }

            _dbContext.Stores.Remove(store);
            return true;

        }

        public async Task<bool> Update(Guid id, CentETE.Domain.Entities.Store obj)
        {
            var store = await _dbContext.Stores.FindAsync(id);

            if (store is null)
            {
                return false;
            }

            store.Update(
                obj.Name,
                obj.Address,
                obj.Status
                // các field cần update
            );
            return true;
        }
    }
}
