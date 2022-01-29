using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HelperlandProject.Models
{
    public partial class Contactu
    {
        public int ContactusId { get; set; }

        
        [RegularExpression("^([A-Z a-z]([A-Z a-z]+))$", ErrorMessage ="Enter upper and lower case alphabets only")]
        public string FirstName { get; set; }

        [RegularExpression("^([A-Z a-z]([A-Z a-z]+))$", ErrorMessage = "Enter upper and lower case alphabets only")]
        public string LastName { get; set; }

        [RegularExpression("^[6789][0-9]{9}$", ErrorMessage = "Enter valid mobile number")]
        public string MobileNo { get; set; }

        
        public string Email { get; set; }
        public string SubjectType { get; set; }
        public string Msg { get; set; }
    }

    
}
