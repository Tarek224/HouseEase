using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("Fuclty")]
    public class Fuclty : BaseEntity
    {
        public string? Name { get; set; }

        public int? UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University? University { get; set; }

        public virtual ICollection<ApplicationUser>? Students { get; set; }
    }
}
