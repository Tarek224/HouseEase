using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HouseEase.Models
{
    [Table ("Leese")]
    public class Leese
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        [ForeignKey("Tentant")]
        public string? TentantId { get; set; }
        [ForeignKey("Owner")]
        public string? OwnerId { get; set; }
        public int? BedsNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }

        [InverseProperty("TentantLeeses")]
        public virtual ApplicationUser? Tentant { get; set; }
        [InverseProperty("OwnerLeeses")]
        public virtual ApplicationUser? Owner { get; set; }

    }
}
