
namespace ProyectoLaboBackEnd.Models.Comment.Dto
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int PostId { get; set; } 
        public int UserId { get; set; }
        public string? MainContent { get; set; } 
        public string? Media { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
