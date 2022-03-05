using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class Userr
    {
        public Userr()
        {
            FavoriteAndBlockedTargetUser = new HashSet<FavoriteAndBlocked>();
            FavoriteAndBlockedUser = new HashSet<FavoriteAndBlocked>();
            RatingRatingFromNavigation = new HashSet<Rating>();
            RatingRatingToNavigation = new HashSet<Rating>();
            ServiceRequestServiceProvider = new HashSet<ServiceRequest>();
            ServiceRequestUser = new HashSet<ServiceRequest>();
            UserAddress = new HashSet<UserAddress>();
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password and Confirm password do not match")]
        public string Confirmpassword { get; set; }
        public string Mobile { get; set; }
        public int UserTypeId { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string UserProfilePicture { get; set; }
        public bool? IsRegisteredUser { get; set; }
        public string PaymentGatewayUserRef { get; set; }
        public string ZipCode { get; set; }
        public bool? WorksWithPets { get; set; }
        public int? LanguageId { get; set; }
        public int? NationalityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }
        public string BankTokenId { get; set; }
        public string TaxNo { get; set; }
        [NotMapped]
        [Required]
        public string NewPassword { get; set; }

        public virtual ICollection<FavoriteAndBlocked> FavoriteAndBlockedTargetUser { get; set; }
        public virtual ICollection<FavoriteAndBlocked> FavoriteAndBlockedUser { get; set; }
        public virtual ICollection<Rating> RatingRatingFromNavigation { get; set; }
        public virtual ICollection<Rating> RatingRatingToNavigation { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequestServiceProvider { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequestUser { get; set; }
        public virtual ICollection<UserAddress> UserAddress { get; set; }

        //public Userr()
        //{
        //    this.CreatedDate = DateTime.UtcNow;
        //    this.ModifiedDate = DateTime.UtcNow;
        //}
    }
}
