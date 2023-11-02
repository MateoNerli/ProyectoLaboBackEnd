using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.Post.Dto
{
    public class PostsDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;

    }
}
