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
    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, StoreDto?>
    {
        private readonly IStoreReadRepository _storeReadRepository;

        public GetStoreByIdQueryHandler(IStoreReadRepository storeReadRepository)
        {
            _storeReadRepository = storeReadRepository;
        }

        public async Task<StoreDto?> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var store = await _storeReadRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

            return new StoreDto
            {
                Id = store?.Id ?? Guid.Empty,
                Name = store?.Name ?? string.Empty,
                Address = store?.Address ?? string.Empty,
                Status = store?.Status ?? false
            };
        }
    }
}
