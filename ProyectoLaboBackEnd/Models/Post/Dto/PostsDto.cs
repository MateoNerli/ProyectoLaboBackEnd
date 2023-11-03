using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class PostsDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
        public int CommunityId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
