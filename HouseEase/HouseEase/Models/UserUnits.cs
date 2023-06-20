using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table ("UserUnits")]
    public class UserUnits
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? UnitId { get; set; }
        public bool? IsOwner { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit? Unit { get; set; }
    }
}
