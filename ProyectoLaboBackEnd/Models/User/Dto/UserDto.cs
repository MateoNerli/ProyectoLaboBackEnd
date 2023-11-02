using ProyectoLaboBackEnd.Models.Post.Dto;

namespace ProyectoLaboBackEnd.Models.User.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string UserName { get; set; } = null!;

        public List<PostsDto>? Posts { get; set; }
    }
}
