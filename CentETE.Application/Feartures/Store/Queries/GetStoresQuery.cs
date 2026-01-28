using CentETE.Application.Feartures.Store.DTOs;
using CentETE.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Application.Feartures.Store.Queries
{
    public sealed record GetStoresQuery : IRequest<List<StoreDto>>;
}
