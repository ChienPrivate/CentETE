using CentETE.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentETE.Domain.Entities
{
    public class Store
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Address { get; private set; } = string.Empty;
        public bool Status { get; private set; } = false;
        public List<Category?> Categories { get; private set; } = default!;

        private Store(string name,
            string address,
            bool status)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Status = status;
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Store name cannot be empty");
            }
            Name = name;
        }

        public void ChangeAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new DomainException("Store address cannot be empty");
            }
            Address = address;
        }

        public void ChangeStatus(bool status)
        {
            Status = status;
        }

        public static Store Create(string name, 
            string address = null,
            bool status = false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Store name cannot be empty");
            }

            return new Store(name, address, status);
        }

        public void Update(string name, 
            string address, 
            bool status)
        {
            Rename(name);
            ChangeAddress(address);
            ChangeStatus(status);
        }
    }
}
