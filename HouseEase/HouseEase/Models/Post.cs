using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseEase.Models
{
    [Table("Post")]
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity) , Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostContent { get; set; }
        public DateTime? PostDate { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
