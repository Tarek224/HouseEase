using HouseEase.Models;
using System.ComponentModel.DataAnnotations;

namespace HouseEase.ViewModel
{
    public class OwnerViewModel
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? JobTitle { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime? DateOfBirth { get; set; }

        public MaritialStatus MaritialStatus { get; set; }

        [DataType(DataType.PhoneNumber), Display(Name = "Phone Number"), RegularExpression("^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = "The Phone Number Expression Is Invalid")]
        public string? MobileNumber { get; set; }
    }
}
