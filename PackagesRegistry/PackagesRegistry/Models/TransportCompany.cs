using System;
using System.Collections.Generic;

#nullable disable

namespace PackagesRegistry.Models
{
    public partial class TransportCompany
    {
        public TransportCompany()
        {
            Drivers = new HashSet<Driver>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
