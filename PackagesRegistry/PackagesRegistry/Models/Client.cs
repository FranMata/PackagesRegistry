using System;
using System.Collections.Generic;

#nullable disable

namespace PackagesRegistry.Models
{
    public partial class Client
    {
        public Client()
        {
            PackagesInCustodies = new HashSet<PackagesInCustody>();
            PackagesRetireds = new HashSet<PackagesRetired>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? DocumentId { get; set; }
        public string BirthDate { get; set; }

        public virtual ICollection<PackagesInCustody> PackagesInCustodies { get; set; }
        public virtual ICollection<PackagesRetired> PackagesRetireds { get; set; }
    }
}
