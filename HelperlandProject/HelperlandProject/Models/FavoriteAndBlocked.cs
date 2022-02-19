using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class FavoriteAndBlocked
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? TargetUserId { get; set; }
        public bool? IsFavorite { get; set; }
        public bool? IsBlocked { get; set; }

        public virtual Userr TargetUser { get; set; }
        public virtual Userr User { get; set; }
    }
}
