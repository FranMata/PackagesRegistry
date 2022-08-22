using System;
using System.Collections.Generic;

#nullable disable

namespace PackagesRegistry.Models
{
    public partial class Driver
    {
        public Driver()
        {
            PackagesInCustodies = new HashSet<PackagesInCustody>();
            PackagesRetireds = new HashSet<PackagesRetired>();
        }

        public int Id { get; set; }
        public int? CompanyId { get; set; }

        public virtual TransportCompany Company { get; set; }
        public virtual ICollection<PackagesInCustody> PackagesInCustodies { get; set; }
        public virtual ICollection<PackagesRetired> PackagesRetireds { get; set; }
    }
}
