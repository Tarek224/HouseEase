using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("Maintenance")]
    public class Maintenance:Service
    {
        public bool? HasWarranty { get; set; }
        [DataType(DataType.Date)]
        public DateTime? WarrantyFromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? WarrantyToDate { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<UsersMaintenance>? UsersMaintenance { get; set; }
    }
}
