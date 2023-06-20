using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseEase.Models
{
    [Table("UsersLundries")]
    public class UsersLundries
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string? TenantId { get; set; }
        public int? LaundryId { get; set; }

        [ForeignKey("TenantId")]
        public virtual ApplicationUser? Tenant { get; set; }
        [ForeignKey("LaundryId")]
        public virtual Laundry? Laundry { get; set; }
    }
}
