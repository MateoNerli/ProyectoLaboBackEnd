using ProyectoLaboBackEnd.Models.User;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class UpdatePostDto
    {
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(300)]
        public string MainContent { get; set; } = null!;
        public string? Media { get; set; }
    }
}
