using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("City")]
    public class City:BaseEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }

        public int? GovernurateId { get; set; }

        [ForeignKey("GovernurateId")]
        public virtual Governurate? Governurate { get; set; }

        public virtual ICollection<ApplicationUser>? Users { get; set; }
    }
}
