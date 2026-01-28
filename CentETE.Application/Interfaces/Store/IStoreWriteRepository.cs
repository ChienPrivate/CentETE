using CentETE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Application.Interfaces.Store
{
    public interface IStoreWriteRepository
    {
        Task AddAsync(CentETE.Domain.Entities.Store store);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, CentETE.Domain.Entities.Store? obj);
    }
}
