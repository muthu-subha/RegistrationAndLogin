using System;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(BookingDetailMetaData))]
    public partial class BookingDetail
    {

    }
    public class BookingDetailMetaData
    {

        [DisplayAttribute(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Field is Required")]
        public String Name { get; set; }

        [DisplayAttribute(Name = "Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is Required")]
        [DisplayAttribute(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayAttribute(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Stylist Name is Required")]
        [DisplayAttribute(Name = "Stylist Name")]
        public string StylistName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Service is Required")]
        [DisplayAttribute(Name = "Service Needed")]
        public string StylistService { get; set; }

        [Required]
        [DisplayAttribute(Name = "Booking Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateForBooking { get; set; }

        [Required]
        [DisplayAttribute(Name = "Booking Time")]
        [DataType(DataType.Time)]
        public TimeSpan TimeForBooking { get; set; }


    }
}
