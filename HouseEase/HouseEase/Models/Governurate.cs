using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("Governurate")]
    public class Governurate:BaseEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }

        public virtual ICollection<ApplicationUser>? Users { get; set; }

        public virtual ICollection<City>? Cities { get; set; }
    }
}
