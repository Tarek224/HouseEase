using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("University")]
    public class University:BaseEntity
    {
        public string? Name { get; set; }

        public string? Location { get; set; }

        public virtual ICollection<Fuclty>? Fuclties { get; set; }

        public virtual ICollection<ApplicationUser>? Users { get; set; }

    }
}
