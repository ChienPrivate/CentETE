using CentETE.Application.Feartures.Store.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Application.Interfaces.Store
{
    public interface IStoreReadRepository
    {
        Task<Domain.Entities.Store?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Domain.Entities.Store>> GetAllAsync(CancellationToken cancellationToken);
    }
}
