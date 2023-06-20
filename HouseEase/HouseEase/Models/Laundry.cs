using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("Laundry")]
    public class Laundry:Service
    {
        public bool? HasDelivery { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<UsersLundries>? UsersLundries { get; set; }
    }
}
