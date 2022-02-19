using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int ServiceRequestId { get; set; }
        public int? RatingFrom { get; set; }
        public int? RatingTo { get; set; }
        public decimal? Ratings { get; set; }
        public string Comments { get; set; }
        public DateTime? RatingDate { get; set; }
        public decimal? OnTimeArrival { get; set; }
        public decimal? Friendly { get; set; }
        public decimal? QualityOfService { get; set; }

        public virtual Userr RatingFromNavigation { get; set; }
        public virtual Userr RatingToNavigation { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
