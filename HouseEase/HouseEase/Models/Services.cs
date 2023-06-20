using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    public class Service:BaseEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public double? Phone { get; set; }
        public string? Describtion { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
