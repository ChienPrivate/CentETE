using CentETE.Application.Feartures.Store.DTOs;
using CentETE.Application.Interfaces.Store;
using CentETE.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Infrastructure.Repositories.Store
{

    public class StoreReadRepository : IStoreReadRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StoreReadRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entities.Store>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Stores
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public Task<Domain.Entities.Store?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => _dbContext.Stores.FindAsync(id).AsTask();
    }
}
