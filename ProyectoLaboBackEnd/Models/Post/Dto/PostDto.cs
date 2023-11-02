using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string MainContent { get; set; }
        public string? Media { get; set; }
        public int CommunityId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
