using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class UpdatePostDto
    {
        [MaxLength(50)]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
