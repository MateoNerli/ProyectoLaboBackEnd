using ProyectoLaboBackEnd.Models.User;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class UpdatePostDto
    {
        [MaxLength(50)]
        public string?  Title { get; set; }
        [MaxLength(300)]
        public string? MainContent { get; set; }
        public string? Media { get; set; }
    }
}
