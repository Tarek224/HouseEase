using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseEase.Models
{
    [Table("UsersMaintenance")]
    public class UsersMaintenance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string? TenantId { get; set; }
        public int? MaintenanceId { get; set; }

        [ForeignKey("TenantId")]
        public virtual ApplicationUser? Tenant { get; set; }
        [ForeignKey("LaundryId")]
        public virtual Maintenance? Maintenance { get; set; }
    }
}
