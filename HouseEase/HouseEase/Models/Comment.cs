using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseEase.Models
{
    [Table("Comment")]
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CommentDate { get; set; }
        public int? PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post? Post { get; set; }
    }
}
