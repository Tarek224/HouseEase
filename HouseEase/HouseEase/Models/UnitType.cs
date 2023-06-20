namespace HouseEase.Models
{
    public class UnitType : BaseEntity
    {
        public string? Name { get; set; }

        public virtual ICollection<Unit>? Units { get; set; }
    }
}
