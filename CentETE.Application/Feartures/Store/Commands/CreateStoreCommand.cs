using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Application.Feartures.Store.Commands
{
    public record CreateStoreCommand(string Name, string Address, bool Status) : IRequest<Guid>
    {

    }
}
