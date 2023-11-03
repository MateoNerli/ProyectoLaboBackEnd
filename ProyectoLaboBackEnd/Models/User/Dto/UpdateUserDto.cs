using System.ComponentModel.DataAnnotations;

namespace ProyectoLaboBackEnd.Models.User.Dto
{
    public class UpdateUserDto
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pfp { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
    }
}
