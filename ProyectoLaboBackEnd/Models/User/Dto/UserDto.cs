using ProyectoLaboBackEnd.Models.Post.Dto;

namespace ProyectoLaboBackEnd.Models.User.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Pfp { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }

        public List<PostsDto>? Posts { get; set; }
    }
}
