using ProyectoLaboBackEnd.Models.User.Dto;

namespace ProyectoLaboBackEnd.Models.User.Dto
{
    public class UsersDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public string Pfp { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }

        public List<UsersDto> Users { get; set; } = new List<UsersDto>();

    }
}
