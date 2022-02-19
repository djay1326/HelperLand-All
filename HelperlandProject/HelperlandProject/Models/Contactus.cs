using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class Contactus
    {
        [Key]
        public int ContactusId { get; set; }


        [RegularExpression("^([A-Z a-z]([A-Z a-z]+))$", ErrorMessage = "Enter upper and lower case alphabets only")]
        public string FirstName { get; set; }

        [RegularExpression("^([A-Z a-z]([A-Z a-z]+))$", ErrorMessage = "Enter upper and lower case alphabets only")]
        public string LastName { get; set; }

        [RegularExpression("^[6789][0-9]{9}$", ErrorMessage = "Enter valid mobile number")]
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string SubjectType { get; set; }
        public string Msg { get; set; }
        public string UploadFileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string FileName { get; set; }
    }
}
