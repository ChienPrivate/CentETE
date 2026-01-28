using CentETE.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid StoreId { get; set; }

        public Store Store { get; set; } = null!;
    }
}
