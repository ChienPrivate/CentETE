using CentETE.Application.Feartures.Store.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Application.Feartures.Store.Queries
{
    public sealed record GetStoreByIdQuery(Guid Id) : IRequest<StoreDto?>;
}
