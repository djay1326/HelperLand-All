using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelperlandProject.Models
{
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            Rating = new HashSet<Rating>();
            ServiceRequestAddress = new HashSet<ServiceRequestAddress>();
            ServiceRequestExtra = new HashSet<ServiceRequestExtra>();
        }

        public int ServiceRequestId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public string ZipCode { get; set; }
        public decimal? ServiceHourlyRate { get; set; }
        public double ServiceHours { get; set; }
        public double? ExtraHours { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalCost { get; set; }
        public string Comments { get; set; }
        public string PaymentTransactionRefNo { get; set; }
        public bool? PaymentDue { get; set; }
        public int? ServiceProviderId { get; set; }
        public DateTime? SpacceptedDate { get; set; }
        public bool? HasPets { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public decimal? RefundedAmount { get; set; }
        public decimal? Distance { get; set; }
        public bool? HasIssue { get; set; }
        public bool? PaymentDone { get; set; }
        public Guid? RecordVersion { get; set; }
        [NotMapped]
        public int AddressId { get; set; }
        public virtual Userr ServiceProvider { get; set; }
        public virtual Userr User { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<ServiceRequestAddress> ServiceRequestAddress { get; set; }
        public virtual ICollection<ServiceRequestExtra> ServiceRequestExtra { get; set; }
    }
}
