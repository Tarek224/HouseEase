using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    public enum MaritialStatus
    {
        Single ,
        Married,
        Engaged,
        Devorce
    }
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public string? Address { get; set; }

        public string? JobTitle { get; set; }

        public bool? IsTenant { get; set; }

        public bool IsSmoking { get; set; }

        [DataType(DataType.Date) , Required]
        public DateTime? DateOfBirth { get; set; }

        public MaritialStatus MaritialStatus { get; set; }

        public int? FucltyId { get; set; }

        public int? CityId { get; set; }

        public int? GovernurateId { get; set; }

        public int? UniversityId { get; set; }

        [ForeignKey("FucltyId")]
        public virtual Fuclty? Fuclty { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University? University { get; set; }

        [ForeignKey("CityId")]
        public virtual City? City  { get; set; }

        [ForeignKey("GovernurateId")]
        public virtual Governurate? Governurate { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }

        public virtual ICollection<UserUnits>? UserUnits { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<Leese>? OwnerLeeses { get; set; }
        [InverseProperty("Tentant")]
        public virtual ICollection<Leese>? TentantLeeses { get; set; }

        public virtual Service? Services { get; set; }

        public virtual ICollection<UsersLundries>? UsersLundries { get; set; }

        public virtual ICollection<UsersMaintenance>? UsersMaintenances { get; set; }
    }
}
