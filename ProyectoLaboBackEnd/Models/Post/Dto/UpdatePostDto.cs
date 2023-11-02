using ProyectoLaboBackEnd.Models.User;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class UpdatePostDto
    {
        public string Title { get; set; }
        public string MainContent { get; set; }
        public string? Media { get; set; }
    }
}
