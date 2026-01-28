using CentETE.Application.Interfaces;
using CentETE.Application.Interfaces.Store;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Application.Feartures.Store.Commands
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Guid>
    {
        private readonly IStoreWriteRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStoreCommandHandler(IStoreWriteRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = CentETE.Domain.Entities.Store.Create(request.Name, request.Address, request.Status);

            await _storeRepository.AddAsync(store);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return store.Id;
        }
    }
}
