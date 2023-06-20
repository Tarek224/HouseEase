using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("Unit")]
    public class Unit : BaseEntity
    {
        public string? Location { get; set; }
        public string? City { get; set; }
        public int? UnitNumber { get; set; }
        public int? FloorsNumber { get; set; }
        public int? RoomsNumber { get; set; }
        public string? Details { get; set; }
        public int? UnitCapacity { get; set; }
        public int? BedsAvailable { get; set; }
        public double? UnitArea { get; set; }
        public int? UnitTypeId { get; set; }
        public double? MonthlyPrice { get; set; }

        [ForeignKey("UnitTypeId")]
        public virtual UnitType? UnitType { get; set; }

        public virtual ICollection<UserUnits>? UserUnits { get; set; }
    }
}
