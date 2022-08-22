using System;
using System.Collections.Generic;

#nullable disable

namespace PackagesRegistry.Models
{
    public partial class PackagesRetired
    {
        public int Id { get; set; }
        public int? DriverId { get; set; }
        public string TrackingId { get; set; }
        public string Description { get; set; }
        public int? ClientId { get; set; }
        public string ReiredDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
