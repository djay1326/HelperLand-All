using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class City
    {
        public City()
        {
            Zipcode = new HashSet<Zipcode>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Zipcode> Zipcode { get; set; }
    }
}
