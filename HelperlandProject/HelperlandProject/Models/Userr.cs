using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class Userr
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int UserTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Userr()
        {
            this.CreatedDate = DateTime.UtcNow;
            //this.ModifiedDate = DateTime.UtcNow;
        }
    }
    
}
