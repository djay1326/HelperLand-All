using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class Zipcode
    {
        public int Id { get; set; }
        public string ZipcodeValue { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
