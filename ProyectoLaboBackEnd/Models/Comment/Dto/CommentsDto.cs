using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Comment.Dto
{
    public class CommunitysDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
        public int CommunityId { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<CommunityDto> Comments { get; set; } = new List<CommunityDto>();
    }
}
