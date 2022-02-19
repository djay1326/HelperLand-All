using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class ServiceRequestExtra
    {
        public int ServiceRequestExtraId { get; set; }
        public int ServiceRequestId { get; set; }
        public int? ServiceExtraId { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
