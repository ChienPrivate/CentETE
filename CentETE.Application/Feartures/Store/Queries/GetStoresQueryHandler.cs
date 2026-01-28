using CentETE.Application.Feartures.Store.DTOs;
using CentETE.Application.Interfaces.Store;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Application.Feartures.Store.Queries
{
    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, List<StoreDto>>
    {
        private readonly IStoreReadRepository _storeReadRepository;

        public GetStoresQueryHandler(IStoreReadRepository storeReadRepository)
        {
            _storeReadRepository = storeReadRepository;
        }

        public async Task<List<StoreDto>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = await _storeReadRepository.GetAllAsync(cancellationToken);

            var storeDtos = stores.Select(store => new StoreDto
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address ?? string.Empty,
                Status = store.Status 
            }).ToList();

            return storeDtos;
        }
    }
}
